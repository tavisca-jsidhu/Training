using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using WebServer.Model;

namespace WebServer.Model
{
    class Dispatcher
    {
        private Socket _clientSocket;
        private string _contentPath;
        private Encoding _charEncoder = Encoding.UTF8;

        public Dispatcher()
        {
            _contentPath = ConfigurationManager.AppSettings["virtual-directory"];
        }

        public void AcceptRequest()
        {
            try
            {
                // Create new thread to handle the request and continue to listen the socket.
                Application.RequestQueue.TryDequeue(out _clientSocket);
                Task.Factory.StartNew(() =>
                {
                    this.HandleTheRequest(_clientSocket);
                });
            }
            catch
            {
                Console.WriteLine("Error in accepting client request");
                Console.ReadLine();
                if (_clientSocket != null)
                    _clientSocket.Close();
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(clientSocket);
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var createResponse = new Processor(clientSocket, _contentPath);
                createResponse.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Console.WriteLine("unemplimented mothode");
                Console.ReadLine();
            }
            StopClientSocket(clientSocket);
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                Console.ReadLine();
            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
        internal void Stop()
        {
            _clientSocket.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Model
{
    public class Server
    {
        private Listener _listner;
        private Dispatcher _dispatcher;

        public Server(string host, int port)
        {
            this._listner = new Listener(host, port);
            this._dispatcher = new Dispatcher();
        }

        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                _dispatcher.AcceptRequest();
            });
            Task.Factory.StartNew(() =>
            {
                _listner.Listen();
            });
        }

        public void Stop()
        {
            _listner.Stop();
            _dispatcher.Stop();
        }
    }
}

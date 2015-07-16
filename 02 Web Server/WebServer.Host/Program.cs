using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = ConfigurationManager.AppSettings["webserver-host"];
            if (string.IsNullOrEmpty(host))
                throw new Exception("Host is invalid");

            int port = 0;
            if (int.TryParse(ConfigurationManager.AppSettings["webserver-port"], out port) == false)
                throw new Exception("Port is invalid");

            var server = new Server(host, port);
            server.Start();

            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();

            server.Stop();
        }
    }
}

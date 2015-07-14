using System;
using System.Collections.Generic;
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
            WebServer.Model.WebServer webserver = new Model.WebServer();
            webserver.Start(8080,@"C:\Users\jsidhu\Downloads\startbootstrap-sb-admin-1.0.3");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Owin.Hosting.WebApp;

namespace Backlog.IntegrationTests
{
    public class ServerFixture<TStartUp> : IDisposable
        where TStartUp: class
    {

        private IDisposable _host;
        public ServerFixture()
        {
            Url = "http://localhost:" + GetNextPort();
        }

        public void Dispose()
        {
            _host.Dispose();
        }

        public string Url { get; private set; }

        public void StartServer(string url) {
            _host = Microsoft.Owin.Hosting.WebApp.Start<TStartUp>( url:url );
        }

        private int GetNextPort()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
                return ((IPEndPoint)socket.LocalEndPoint).Port;
            }
        }
    }
}

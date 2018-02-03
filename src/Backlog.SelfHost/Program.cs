using CommandLine;
using Microsoft.Owin.Cors;
using Owin;
using System.Net;
using System.Net.Sockets;
using System.Web.Http;
using Unity.WebApi;
using static CommandLine.Parser;
using static Microsoft.Owin.Hosting.WebApp;
using static System.Console;

namespace Backlog.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Url = $"http://localhost:{GetNextPort()}/";            
            Start<Startup>(url: Url);
            WriteLine($"Api Hosted at: {Url}");
            ReadLine();
        }

        private static int GetNextPort()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
                return ((IPEndPoint)socket.LocalEndPoint).Port;
            }
        }

        public static string Url { get; set; }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
            ApiConfiguration.Install(config, app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
    
}

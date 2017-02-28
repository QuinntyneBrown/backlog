using CommandLine;
using Microsoft.Owin.Cors;
using Owin;
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
            var options = new SelfHostOptions();
            Default.ParseArguments(args, options);
            string host = string.IsNullOrEmpty(options.Port) ? "localhost:50225" : $"localhost:{options.Port}";
            host = string.IsNullOrEmpty(options.Host) ? host : options.Host;
            string baseAddress = $"http://{host}/";
            Start<Startup>(url: baseAddress);
            WriteLine($"Api Hosted at: {baseAddress}");
            ReadLine();
        }

        class SelfHostOptions
        {
            [Option("host", Required = false, HelpText = "Host")]
            public string Host { get; set; }

            [Option("port", Required = false, HelpText = "Port")]
            public string Port { get; set; }
        }

        class Startup
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
}

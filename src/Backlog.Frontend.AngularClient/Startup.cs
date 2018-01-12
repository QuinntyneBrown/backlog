using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Backlog.Frontend.AngularClient.Startup))]

namespace Backlog.Frontend.AngularClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
                ApiConfiguration.Install(config, app);
            });
        }
    }
}

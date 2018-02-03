using Backlog.SelfHost;
using Microsoft.Owin.Testing;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System.Net.Http;
using System.Web.Http;
using Unity.WebApi;
using static Backlog.ApiConfiguration;

namespace Backlog.IntegrationTests.Features.Epics
{
    [TestClass]
    public class GetEpicsTest
    {
        private TestServer _testServer { get; set; }
        
        [TestInitialize]
        public void Setup()
        {
            _testServer = TestServer.Create(app =>
            {
                var config = new HttpConfiguration();
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());                
                Install(config, app);
                app.UseWebApi(config);
            });
        }
    }
}

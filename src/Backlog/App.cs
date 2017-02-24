using Owin;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;
using Swashbuckle.Application;
using Microsoft.Owin.Cors;
using System;
using Backlog.Features.Core;
using Backlog.Security;
using System.Web.Http.Cors;
using MediatR;
using System.Configuration;
using System.Reflection;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace Backlog
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);
            var container = UnityConfiguration.GetContainer();

            app.MapSignalR();

            config.Filters.Add(new HandleErrorAttribute(UnityConfiguration.GetContainer().Resolve<ILoggerFactory>()));

            app.UseCors(CorsOptions.AllowAll);

            config.SuppressHostPrincipal();

            var mediator = container.Resolve<IMediator>();
            Lazy<IAuthConfiguration> lazyAuthConfiguration = UnityConfiguration.GetContainer().Resolve<Lazy<IAuthConfiguration>>();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Backlog"))
                .EnableSwaggerUi();

            app.UseOAuthAuthorizationServer(new OAuthOptions(lazyAuthConfiguration, mediator));

            app.UseJwtBearerAuthentication(new JwtOptions(lazyAuthConfiguration));

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Filters.Add(new AuthorizeAttribute());

            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
			jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jSettings.ContractResolver = new SignalRContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }

    public interface IAppConfiguration
    {
        string BaseUri { get; set; }
    }

    public class AppConfiguration : ConfigurationSection, IAppConfiguration
    {

        [ConfigurationProperty("baseUri")]
        public string BaseUri
        {
            get { return (string)this["baseUri"]; }
            set { this["baseUri"] = value; }
        }

        public static IAppConfiguration Config
        {
            get { return ConfigurationManager.GetSection("appConfiguration") as IAppConfiguration; }
        }
    }

    public class SignalRContractResolver : IContractResolver
    {
        private readonly Assembly assembly;
        private readonly IContractResolver camelCaseContractResolver;
        private readonly IContractResolver defaultContractSerializer;

        public SignalRContractResolver()
        {
            defaultContractSerializer = new DefaultContractResolver();
            camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
            assembly = typeof(Connection).Assembly;
        }

        public JsonContract ResolveContract(Type type)
        {
            if (type.Assembly.Equals(assembly))
            {
                return defaultContractSerializer.ResolveContract(type);
            }
            return camelCaseContractResolver.ResolveContract(type);
        }

    }

    public class Constants
    {
        public static string VERSION = "1.0.0-alpha.0";
        public const int CacheOutputClientTimeSpan = 3600;
        public const int CacheOutputServerTimeSpan = 3600;
    }
}

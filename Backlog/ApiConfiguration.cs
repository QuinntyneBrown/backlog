using Owin;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;
using Swashbuckle.Application;
using Microsoft.Owin.Cors;
using System;
using Backlog.App_Start;
using Backlog.Utilities;
using Backlog.Configuration;
using Backlog.Services;
using Backlog.Authentication;
using Backlog.Filters;

namespace Backlog
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);

            app.MapSignalR();


            config.Filters.Add(new HandleErrorAttribute(UnityConfiguration.GetContainer().Resolve<ILoggerFactory>()));

            app.UseCors(CorsOptions.AllowAll);

            config.SuppressHostPrincipal();

            IIdentityService identityService = UnityConfiguration.GetContainer().Resolve<IIdentityService>();
            Lazy<IAuthConfiguration> lazyAuthConfiguration = UnityConfiguration.GetContainer().Resolve<Lazy<IAuthConfiguration>>();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Backlog"))
                .EnableSwaggerUi();

            app.UseOAuthAuthorizationServer(new OAuthOptions(lazyAuthConfiguration, identityService));

            app.UseJwtBearerAuthentication(new JwtOptions(lazyAuthConfiguration));

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
			jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}

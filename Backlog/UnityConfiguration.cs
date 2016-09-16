using Backlog.Configuration;
using Backlog.ContentModels;
using Backlog.Data;
using Backlog.Services;
using Backlog.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Backlog
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer().AddNewExtension<Interception>();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IEpicService, EpicService>();
            container.RegisterType<IStoryService, StoryService>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<ILandingPageContentModel, LandingPageContentModel>();
            container.RegisterType<IAppShellContentModel, AppShellContentModel>();

            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}

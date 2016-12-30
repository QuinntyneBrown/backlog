using Backlog.Configuration;
using Backlog.Data;
using Backlog.Data.Repositories;
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
            var container = new UnityContainer();

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
            container.RegisterType<ISprintService, SprintService>();
            container.RegisterType<ITagService, TagService>();
            container.RegisterType<IAgileTeamService, AgileTeamService>();
            container.RegisterType<IThemeService, ThemeService>();
            container.RegisterType<IAppConfiguration, AppConfiguration>();
            container.RegisterType<IHtmlContentService, HtmlContentService>();
            container.RegisterType<IDigitalAssetService, DigitalAssetService>();
            container.RegisterType<IPrioritizationService, PrioritizationService>();
            container.RegisterType<IReusableStoryGroupService, ReusableStoryGroupService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IAgileTeamMemberService, AgileTeamMemberService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IFeedbackService, FeedbackService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<IUserSettingsService, UserSettingsService>();
            container.RegisterType<IKanbanBoardService, KanbanBoardService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IFeatureService, FeatureService>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IIpRepository, IpRepository>();
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}

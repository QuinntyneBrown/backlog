using Backlog.Configuration;
using Backlog.Data;
using Backlog.Data.Repositories;
using Backlog.Services;
using Backlog.Utilities;
using MediatR;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public static class UnityContainerExtension
    {

        public static IUnityContainer AddMediator<T>(this IUnityContainer container)
        {
            var classes = AllClasses.FromAssemblies(typeof(T).Assembly)
                .Where(x => x.Name.Contains("Controller") == false && x.FullName.Contains("Data.Models") == false)
                .ToList();

            return container.RegisterClassesTypesAndInstances(classes);
        }

        public static IUnityContainer AddMediator<T1, T2>(this IUnityContainer container)
        {
            var classes = AllClasses.FromAssemblies(typeof(T1).Assembly)
                .Where(x => x.Name.Contains("Controller") == false && x.FullName.Contains("Data.Models") == false)
                .ToList();

            classes.AddRange(AllClasses.FromAssemblies(typeof(T2).Assembly)
                .Where(x => x.Name.Contains("Controller") == false && x.FullName.Contains("Data.Models") == false)
                .ToList());

            return container.RegisterClassesTypesAndInstances(classes);
        }

        public static IUnityContainer RegisterClassesTypesAndInstances(this IUnityContainer container, IList<Type> classes)
        {
            container.RegisterClasses(classes);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.IsRegistered(t) ? container.Resolve(t) : null);
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            return container;
        }

        public static void RegisterClasses(this IUnityContainer container, IList<Type> types)
            => container.RegisterTypes(types, WithMappings.FromAllInterfaces, container.GetName, container.GetLifetimeManager);

        public static bool IsNotificationHandler(this IUnityContainer container, Type type)
            => type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));

        public static LifetimeManager GetLifetimeManager(this IUnityContainer container, Type type)
            => container.IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;

        public static string GetName(this IUnityContainer container, Type type)
            => container.IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
    }
}

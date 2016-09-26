using Backlog.Models;
using System;

namespace Backlog.Data
{
    public class Uow : IUow
    {
        protected IDbContext dbContext;

        protected IRepositoryProvider RepositoryProvider { get; set; }

        public Uow(IDbContext dbContext = null)
        {
            this.dbContext = dbContext;
            ConfigureDbContext(this.dbContext);
            var repositoryProvider = new RepositoryProvider(new RepositoryFactories());
            repositoryProvider.dbContext = this.dbContext;
            RepositoryProvider = repositoryProvider;
        }

        public Uow(IRepositoryProvider repositoryProvider, IDbContext dbContext = null)
        {
            this.dbContext = dbContext;
            ConfigureDbContext(this.dbContext);
            repositoryProvider.dbContext = this.dbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Epic> Epics { get { return GetStandardRepo<Epic>(); } }
        public IRepository<Story> Stories { get { return GetStandardRepo<Story>(); } }
        public IRepository<User> Users { get { return GetStandardRepo<User>(); } }
        public IRepository<Role> Roles { get { return GetStandardRepo<Role>(); } }
        public IRepository<Sprint> Sprints { get { return GetStandardRepo<Sprint>(); } }
        public IRepository<Tag> Tags { get { return GetStandardRepo<Tag>(); } }
        public IRepository<AgileTeam> AgileTeams { get { return GetStandardRepo<AgileTeam>(); } }
        public IRepository<Theme> Themes { get { return GetStandardRepo<Theme>(); } }
        public IRepository<HtmlContent> HtmlContents { get { return GetStandardRepo<HtmlContent>(); } }
        public IRepository<DigitalAsset> DigitalAssets { get { return GetStandardRepo<DigitalAsset>(); } }
        public IRepository<ReusableStoryGroup> ReusableStoryGroups { get { return GetStandardRepo<ReusableStoryGroup>(); } }
        public IRepository<Project> Projects { get { return GetStandardRepo<Project>(); } }
        public IRepository<AgileTeamMember> AgileTeamMembers {  get { return GetStandardRepo<AgileTeamMember>(); } }

        protected void ConfigureDbContext(IDbContext dbContext)
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        
        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        protected IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        protected T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                }
            }
        }

        #endregion
        
        public void Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

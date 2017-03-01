using Backlog.Data.Helpers;

namespace Backlog.Data.Migrations
{
    public class DbConfiguration: System.Data.Entity.DbConfiguration
    {
        public DbConfiguration()
        {
            AddInterceptor(new SoftDeleteInterceptor());
        }
    }
}

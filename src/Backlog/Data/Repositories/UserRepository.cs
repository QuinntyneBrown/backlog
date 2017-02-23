using Backlog.Models;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Data.Repositories
{
    public class UserRepository : EFRepository<User>
    {
        public UserRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public override IQueryable<User> GetAll() => DbSet
                .Where(x => !x.IsDeleted);

    }
}

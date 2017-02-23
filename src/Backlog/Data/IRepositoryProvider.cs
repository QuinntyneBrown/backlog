using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Data
{
    public interface IRepositoryProvider
    {
        IDbContext dbContext { get; set; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>(Func<IDbContext, object> factory = null) where T : class;

        void SetRepository<T>(T repository);
    }
}

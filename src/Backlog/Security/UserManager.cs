using Backlog.Data.Model;
using System.Threading.Tasks;
using System.Security.Principal;
using Backlog.Data;
using System.Data.Entity;
using System.Linq;

namespace Backlog.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _dataContext.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IDataContext _dataContext;
    }
}

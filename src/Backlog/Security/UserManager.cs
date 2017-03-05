using Backlog.Data.Models;
using System.Threading.Tasks;
using System.Security.Principal;
using Backlog.Data;
using System.Data.Entity;

namespace Backlog.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public async Task<User> GetUserAsync(IPrincipal user) => await _dataContext.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IDataContext _dataContext;
    }
}

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
        public UserManager(IBacklogContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IBacklogContext _context;
    }
}

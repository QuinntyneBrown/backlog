using Backlog.Domain.DataAccess;
using Backlog.Domain.Identity;
using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Backlog.Domain.Services
{
    public interface IUserService
    {
        Task<(Guid userId, string accessToken)> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;
        private readonly ISecurityTokenFactory _factory;
        private readonly IPasswordHasher _hasher;
        public UserService(IAppDbContext context, ISecurityTokenFactory factory, IPasswordHasher hasher)
        {
            _context = context;
            _factory = factory;
            _hasher = hasher;
        }

        public async Task<(Guid userId, string accessToken)> Authenticate(string username, string password)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());

            if (user == null)
                throw new Exception("Invalid username or password");

            if (!ValidateUser(user, _hasher.HashPassword(user.Salt, password)))
                throw new Exception("Invalid username or password");

            return (user.UserId, _factory.Create(user.UserId, username));
        }

        public bool ValidateUser(User user, string transformedPassword)
        {
            if (user == null || transformedPassword == null)
                return false;

            return user.Password == transformedPassword;
        }
    }
}

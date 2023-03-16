using Backlog.Domain.DataAccess;
using Backlog.Domain.Identity;
using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace Backlog.Domain.Services;

public class UserService : IUserService
{
    private readonly IAppDbContext _context;
    private readonly ISecurityTokenFactory _securityTokenFactory;
    private readonly IPasswordHasher _passwordHasher;
    public UserService(IAppDbContext context, ISecurityTokenFactory securityTokenFactory, IPasswordHasher passwordHasher)
    {
        _context = context;
        _securityTokenFactory = securityTokenFactory;
        _passwordHasher = passwordHasher;
    }

    public async Task<(Guid userId, string accessToken)> Authenticate(string username, string password)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());

        if (user == null)
            throw new Exception("Invalid username or password");

        if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, password)))
            throw new Exception("Invalid username or password");

        return (user.UserId, _securityTokenFactory.Create(user.UserId, username));
    }

    public bool ValidateUser(User user, string transformedPassword)
    {
        if (user == null || transformedPassword == null)
            return false;

        return user.Password == transformedPassword;
    }
}

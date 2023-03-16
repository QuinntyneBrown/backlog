using System;
using System.Threading.Tasks;


namespace Backlog.Domain.Services;

public interface IUserService
{
    Task<(Guid userId, string accessToken)> Authenticate(string username, string password);
}

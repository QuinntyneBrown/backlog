using Backlog.Responses;
using System.Collections.Generic;
using System.Security.Claims;

namespace Backlog.Services
{
    public interface IIdentityService
    {

        RegistrationResponse TryToRegister(RegistrationRequest request, IList<string> roles);

        bool AuthenticateUser(string username, string password);

        ICollection<Claim> GetClaimsForUser(string username);
    }
}

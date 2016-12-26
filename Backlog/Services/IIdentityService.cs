using Backlog.Responses;
using System.Collections.Generic;
using System.Security.Claims;

namespace Backlog.Services
{
    public interface IIdentityService
    {

        TokenApiModel TryToRegister(RegistrationRequestDto registrationRequestDto, IList<string> roles);

        bool AuthenticateUser(string username, string password);

        ICollection<Claim> GetClaimsForUser(string username);
    }
}

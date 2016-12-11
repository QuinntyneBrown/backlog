using Backlog.Dtos;
using System.Collections.Generic;
using System.Security.Claims;

namespace Backlog.Services
{
    public interface IIdentityService
    {

        TokenDto TryToRegister(RegistrationRequestDto registrationRequestDto, IList<string> roles);

        bool AuthenticateUser(string username, string password);

        ICollection<Claim> GetClaimsForUser(string username);
    }
}

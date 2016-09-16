using Backlog.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Backlog.Services
{
    public class IdentityService : IIdentityService
    {
        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ICollection<Claim> GetClaimsForUser(string username)
        {
            throw new NotImplementedException();
        }

        public TokenDto TryToRegister(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

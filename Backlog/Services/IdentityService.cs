using Backlog.Data;
using Backlog.Dtos;
using Backlog.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Data.Entity;
using System.Linq;

namespace Backlog.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityService(IUow uow, IEncryptionService encryptionService, ICacheProvider cacheProvider)
        {
            _cache = cacheProvider.GetCache();
            _encryptionService = encryptionService;
            _uow = uow;
        }

        public bool AuthenticateUser(string username, string password)
        {
            if (_uow.Users.GetAll().FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && !x.IsDeleted) != null)
            {
                var transformedPassword = _encryptionService.TransformPassword(password);
                return ValidateUser(username, transformedPassword);
            }
            return false;
        }

        public ICollection<Claim> GetClaimsForUser(string username)
        {
            var claims = new List<System.Security.Claims.Claim>();

            var user = _cache.FromCacheOrService<User>(() => _uow.Users.GetAll()
                .Include(x => x.Roles)
                .Single(x => x.Username == username), string.Format("User: {0}", username));

            claims.Add(new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));

            foreach (var role in user.Roles.Select(x => x.Name))
            {
                claims.Add(new System.Security.Claims.Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
            }

            return claims;
        }

        public TokenDto TryToRegister(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }

        private bool ValidateUser(string usermame, string password)
        {
            return this._uow.Users.GetAll().Where(x => x.Username == usermame && x.Password == password).Count() > 0;
        }

        protected readonly IUow _uow;
        protected readonly ICache _cache;
        protected readonly IEncryptionService _encryptionService;
    }
}

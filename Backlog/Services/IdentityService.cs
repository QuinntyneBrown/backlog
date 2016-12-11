using Backlog.Data;
using Backlog.Dtos;
using Backlog.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Data.Entity;
using System.Linq;
using Backlog.Configuration;
using Backlog.Authentication;
using Microsoft.Owin.Security;

namespace Backlog.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityService(
            IUow uow, 
            IEncryptionService encryptionService, 
            ICacheProvider cacheProvider,
            Lazy<IAuthConfiguration> lazyAuthConfiguration
            )
        {
            _cache = cacheProvider.GetCache();
            _encryptionService = encryptionService;
            _uow = uow;
            _jwtWriterFormat = JwtWriterFormat.Get(lazyAuthConfiguration, this);
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
                .Single(x => x.Username == username), $"User: {username}");
            

            claims.Add(new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));

            foreach (var role in user.Roles.Select(x => x.Name))
            {
                claims.Add(new System.Security.Claims.Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
            }

            return claims;
        }

        public TokenDto TryToRegister(RegistrationRequestDto registrationRequestDto, IList<string> roles)
        {
            if (_uow.Users.GetAll().FirstOrDefault(x => x.Username.ToLower() == registrationRequestDto.EmailAddress.ToLower() && !x.IsDeleted) != null)
                return null;
            
            var user = new User()
            {
                Firstname = registrationRequestDto.Firstname,
                Lastname = registrationRequestDto.Lastname,
                Email = registrationRequestDto.EmailAddress,
                Username = registrationRequestDto.EmailAddress,
                Password = _encryptionService.TransformPassword(registrationRequestDto.Password)
            };

            foreach (var role in roles) { user.Roles.Add(_uow.Roles.GetAll().Where(x => x.Name == role).First()); }

            _uow.Users.Add(user);
            _uow.SaveChanges();

            var authenticationTicket = new AuthenticationTicket(new ClaimsIdentity(GetClaimsForUser(user.Username)), new AuthenticationProperties());
            return new TokenDto() { Token = _jwtWriterFormat.Protect(authenticationTicket) };
        }

        private bool ValidateUser(string usermame, string password)
        {
            return this._uow.Users.GetAll().Where(x => x.Username == usermame && x.Password == password).Count() > 0;
        }

        protected readonly IUow _uow;
        protected readonly ICache _cache;
        protected readonly IEncryptionService _encryptionService;
        protected readonly JwtWriterFormat _jwtWriterFormat;
    }
}

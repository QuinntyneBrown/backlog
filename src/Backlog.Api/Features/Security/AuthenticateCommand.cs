using Backlog.Features.Security;
using System;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;
using System.Collections.Generic;
using System.Security.Claims;
using MediatR;
using Backlog.Data;
using System.Threading.Tasks;

namespace Backlog.Features.Security
{
    public class AuthenticateCommand
    {
        public class AuthenticateRequest : IRequest<AuthenticateResponse>
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class AuthenticateResponse
        {
            public bool IsAuthenticated { get; set; }
        }

        public class AuthenticateHandler : IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>
        {
            public AuthenticateHandler(IBacklogContext context, IEncryptionService encryptionService)
            {
                _encryptionService = encryptionService;
                _context = context;
            }

            public bool ValidateUser(User user, string transformedPassword)
            {
                if (user == null || transformedPassword == null)
                    return false;

                return user.Password == transformedPassword;
            }

            public async Task<AuthenticateResponse> Handle(AuthenticateRequest message)
            {
                var user = await _context.Users
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Username.ToLower() == message.Username.ToLower() && x.Tenant.UniqueId == message.TenantUniqueId);

                return new AuthenticateResponse()
                {
                    IsAuthenticated = ValidateUser(user, _encryptionService.TransformPassword(message.Password))
                };
            }


            protected readonly IBacklogContext _context;
            private IEncryptionService _encryptionService { get; set; }
        }

    }

}

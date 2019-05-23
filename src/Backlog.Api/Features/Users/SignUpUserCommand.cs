using Backlog.Data;
using Backlog.Features.Core;
using Backlog.Features.Security;
using Backlog.Model;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Backlog.Features.Users
{
    public class SignUpUserCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public string Email { get; set; }
            public string FullName { get; set; }
            public string Password { get; set; }
            public string PasswordConfirmation { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var tenant = new Tenant()
                {
                    Name = request.FullName,
                    UniqueId = Guid.NewGuid()
                };

                var user = new User()
                {
                    Tenant = tenant,
                    Username = request.Email,
                    Password = _encryptionService.TransformPassword(request.Password)
                };

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                throw new System.NotImplementedException();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
            private readonly IEncryptionService _encryptionService;
        }
    }
}
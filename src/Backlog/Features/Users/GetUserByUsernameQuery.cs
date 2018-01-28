using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Users
{
    public class GetUserByUsernameQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserByUsernameHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetUserByUsernameHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                return new Response()
                {
                    User = UserApiModel.FromUser(await _context.Users
                    .Include(x => x.Tenant)
                    .Include(x => x.Profile)
                    .SingleAsync(x=>x.Username == request.Username 
                    && x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
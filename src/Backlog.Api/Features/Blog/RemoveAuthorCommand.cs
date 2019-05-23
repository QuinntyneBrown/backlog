using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class RemoveAuthorCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveAuthorHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveAuthorHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                _context.Authors.Remove(await _context.Authors
                    .Include(x => x.Tenant)                    
                    .SingleAsync(x => x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId));

                await _context.SaveChangesAsync(request.Username);

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
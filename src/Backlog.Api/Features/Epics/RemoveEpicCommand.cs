using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backlog.Features.Epics
{
    public class RemoveEpicCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveEpicHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveEpicHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var epic = await _context.Epics
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.Tenant.UniqueId == request.TenantUniqueId);

                epic.IsDeleted = true;

                await _context.SaveChangesAsync(request.Username);

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

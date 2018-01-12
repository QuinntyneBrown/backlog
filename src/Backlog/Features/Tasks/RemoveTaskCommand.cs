using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Backlog.Features.Tasks
{
    public class RemoveTaskCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveTaskHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveTaskHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var task = await _context.Tasks
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleAsync(x => x.Id == request.Id);

                task.IsDeleted = true;

                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

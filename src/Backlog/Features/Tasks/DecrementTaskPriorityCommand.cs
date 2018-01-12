using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;
using Backlog.Model;

namespace Backlog.Features.Tasks
{
    public class DecrementTaskPriorityCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> {
            public int Id { get; set; }
        }

        public class Response { }

        public class DecrementTaskPriorityHandler : IAsyncRequestHandler<Request, Response>
        {
            public DecrementTaskPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var task = await _context.Tasks
                    .Include(x =>x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleAsync(x =>x.Id == request.Id);

                var tasks = await _context.Tasks
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .ToListAsync();
                
                task.DecrementPriority(new List<IPrioritizable>(tasks.Cast<IPrioritizable>()));

                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
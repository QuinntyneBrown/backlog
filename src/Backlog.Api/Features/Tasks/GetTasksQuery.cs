using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tasks
{
    public class GetTasksQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<TaskApiModel> Tasks { get; set; } = new HashSet<TaskApiModel>();
        }

        public class GetTasksHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetTasksHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var tasks = await _context.Tasks
                    .Include(x => x.Tenant)
                    .Where(x =>x.Tenant.UniqueId == request.TenantUniqueId)
                    .ToListAsync();

                return new Response()
                {
                    Tasks = tasks.Select(x => TaskApiModel.FromTask(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tasks
{
    public class GetTaskByIdQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public TaskApiModel Task { get; set; } 
		}

        public class GetTaskByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetTaskByIdHandler(IBacklogContext context, ICache cache)
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

                return new Response()
                {
                    Task = TaskApiModel.FromTask(task)
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
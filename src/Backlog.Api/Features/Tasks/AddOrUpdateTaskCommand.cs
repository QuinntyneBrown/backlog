using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using Task = Backlog.Model.Task;

namespace Backlog.Features.Tasks
{
    public class AddOrUpdateTaskCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public TaskApiModel Task { get; set; }
        }

        public class Response { }

        public class AddOrUpdateTaskHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateTaskHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Tasks
                    .SingleOrDefaultAsync(x => x.Id == request.Task.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                if (entity == null)
                {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Tasks.Add(entity = new Task()
                    {
                        TenantId = tenant.Id
                    });
                }

                entity.Name = request.Task.Name;

                await _context.SaveChangesAsync();

                return new Response() {};
            }

            protected readonly IBacklogContext _context;
            protected readonly ICache _cache;
        }
    }
}
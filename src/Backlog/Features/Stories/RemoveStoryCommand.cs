using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class RemoveStoryCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveStoryHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveStoryHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var story = await _context.Stories
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleAsync(x =>x.Id == request.Id);

                story.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class GetStoryByIdQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public StoryApiModel Story { get; set; } 
		}

        public class GetStoryByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetStoryByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Story = StoryApiModel.FromStory(await _context.Stories
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleAsync(x =>x.Id == request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

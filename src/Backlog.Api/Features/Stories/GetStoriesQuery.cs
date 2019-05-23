using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class GetStoriesQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<StoryApiModel> Stories { get; set; } = new HashSet<StoryApiModel>();
        }

        public class GetStoriesHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetStoriesHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var stories = await _context.Stories
                    .Include(x =>x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .ToListAsync();

                return new Response()
                {
                    Stories = stories.Select(x => StoryApiModel.FromStory(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

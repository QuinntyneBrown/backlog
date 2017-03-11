using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class RemoveStoryCommand
    {
        public class RemoveStoryRequest : IRequest<RemoveStoryResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveStoryResponse { }

        public class RemoveStoryHandler : IAsyncRequestHandler<RemoveStoryRequest, RemoveStoryResponse>
        {
            public RemoveStoryHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveStoryResponse> Handle(RemoveStoryRequest request)
            {
                var story = await _context.Stories.FindAsync(request.Id);
                story.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveStoryResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

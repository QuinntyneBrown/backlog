using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
{
    public class RemoveTagCommand
    {
        public class RemoveTagRequest : IRequest<RemoveTagResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTagResponse { }

        public class RemoveTagHandler : IAsyncRequestHandler<RemoveTagRequest, RemoveTagResponse>
        {
            public RemoveTagHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveTagResponse> Handle(RemoveTagRequest request)
            {
                var tag = await _context.Tags.FindAsync(request.Id);
                tag.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveTagResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

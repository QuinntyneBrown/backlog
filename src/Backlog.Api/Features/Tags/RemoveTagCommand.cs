using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Tags
{
    public class RemoveTagCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveTagHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveTagHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var tag = await _context.Tags.FindAsync(request.Id);
                tag.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

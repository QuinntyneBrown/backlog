using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Blog
{
    public class RemoveAuthorCommand
    {
        public class RemoveAuthorRequest : IRequest<RemoveAuthorResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAuthorResponse { }

        public class RemoveAuthorHandler : IAsyncRequestHandler<RemoveAuthorRequest, RemoveAuthorResponse>
        {
            public RemoveAuthorHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveAuthorResponse> Handle(RemoveAuthorRequest request)
            {
                var author = await _context.Authors.FindAsync(request.Id);
                author.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveAuthorResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
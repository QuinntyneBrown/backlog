using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class GetAuthorsQuery
    {
        public class GetAuthorsRequest : IRequest<Response> { }

        public class Response
        {
            public ICollection<AuthorApiModel> Authors { get; set; } = new HashSet<AuthorApiModel>();
        }

        public class GetAuthorsHandler : IAsyncRequestHandler<GetAuthorsRequest, Response>
        {
            public GetAuthorsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(GetAuthorsRequest request)
            {
                var authors = await _context.Authors.ToListAsync();
                return new Response()
                {
                    Authors = authors.Select(x => AuthorApiModel.FromAuthor(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

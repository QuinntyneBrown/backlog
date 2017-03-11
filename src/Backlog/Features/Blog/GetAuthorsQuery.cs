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
        public class GetAuthorsRequest : IRequest<GetAuthorsResponse> { }

        public class GetAuthorsResponse
        {
            public ICollection<AuthorApiModel> Authors { get; set; } = new HashSet<AuthorApiModel>();
        }

        public class GetAuthorsHandler : IAsyncRequestHandler<GetAuthorsRequest, GetAuthorsResponse>
        {
            public GetAuthorsHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAuthorsResponse> Handle(GetAuthorsRequest request)
            {
                var authors = await _dataContext.Authors.ToListAsync();
                return new GetAuthorsResponse()
                {
                    Authors = authors.Select(x => AuthorApiModel.FromAuthor(x)).ToList()
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

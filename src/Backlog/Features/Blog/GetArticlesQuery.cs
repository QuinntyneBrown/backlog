using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class GetArticlesQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<ArticleApiModel> Articles { get; set; } = new HashSet<ArticleApiModel>();
        }

        public class GetArticlesHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetArticlesHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var articles = await _context.Articles
                    .Include(x=>x.Author)
                    .ToListAsync();

                return new Response()
                {
                    Articles = articles.Select(x => ArticleApiModel.FromArticle(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

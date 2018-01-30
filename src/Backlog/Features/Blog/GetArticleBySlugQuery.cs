using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Backlog.Features.Blog
{
    public class GetArticleBySlugQuery
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public string Slug { get; set; }
        }

        public class Response
        {
            public ArticleApiModel Article { get; set; }
        }

        public class GetArticleBySlugHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetArticleBySlugHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                return new Response()
                {
                    Article = ArticleApiModel.FromArticle(await _context.Articles
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleAsync(a => a.Slug == request.Slug))
                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class GetArticleBySlugQuery
    {
        public class GetArticleBySlugRequest : IRequest<GetArticleBySlugResponse>
        {
            public string Slug { get; set; }
        }

        public class GetArticleBySlugResponse
        {
            public ArticleApiModel Article { get; set; }
        }

        public class GetArticleBySlugHandler : IAsyncRequestHandler<GetArticleBySlugRequest, GetArticleBySlugResponse>
        {
            public GetArticleBySlugHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetArticleBySlugResponse> Handle(GetArticleBySlugRequest request)
            {
                return new GetArticleBySlugResponse()
                {
                    Article = ArticleApiModel.FromArticle(await _dataContext.Articles.SingleAsync(a => a.Slug == request.Slug))
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

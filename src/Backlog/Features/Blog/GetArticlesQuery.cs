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
        public class GetArticlesRequest : IRequest<GetArticlesResponse> { }

        public class GetArticlesResponse
        {
            public ICollection<ArticleApiModel> Articles { get; set; } = new HashSet<ArticleApiModel>();
        }

        public class GetArticlesHandler : IAsyncRequestHandler<GetArticlesRequest, GetArticlesResponse>
        {
            public GetArticlesHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetArticlesResponse> Handle(GetArticlesRequest request)
            {
                var articles = await _dataContext.Articles.ToListAsync();
                return new GetArticlesResponse()
                {
                    Articles = articles.Select(x => ArticleApiModel.FromArticle(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

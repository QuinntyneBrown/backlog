using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class GetArticleByIdQuery
    {
        public class GetArticleByIdRequest : IRequest<GetArticleByIdResponse> { 
            public int Id { get; set; }
        }

        public class GetArticleByIdResponse
        {
            public ArticleApiModel Article { get; set; } 
        }

        public class GetArticleByIdHandler : IAsyncRequestHandler<GetArticleByIdRequest, GetArticleByIdResponse>
        {
            public GetArticleByIdHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetArticleByIdResponse> Handle(GetArticleByIdRequest request)
            {                
                return new GetArticleByIdResponse()
                {
                    Article = ArticleApiModel.FromArticle(await _dataContext.Articles
                    .Include(x=>x.Author)
                    .SingleAsync(x=> x.Id == request.Id))
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
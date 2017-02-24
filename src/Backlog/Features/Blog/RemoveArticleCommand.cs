using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Blog
{
    public class RemoveArticleCommand
    {
        public class RemoveArticleRequest : IRequest<RemoveArticleResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveArticleResponse { }

        public class RemoveArticleHandler : IAsyncRequestHandler<RemoveArticleRequest, RemoveArticleResponse>
        {
            public RemoveArticleHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveArticleResponse> Handle(RemoveArticleRequest request)
            {
                var article = await _dataContext.Articles.FindAsync(request.Id);
                article.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveArticleResponse();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using Backlog.Data.Model;

namespace Backlog.Features.Blog
{
    public class AddOrUpdateArticleCommand
    {
        public class AddOrUpdateArticleRequest : IRequest<AddOrUpdateArticleResponse>
        {
            public ArticleApiModel Article { get; set; }
        }

        public class AddOrUpdateArticleResponse { }

        public class AddOrUpdateArticleHandler : IAsyncRequestHandler<AddOrUpdateArticleRequest, AddOrUpdateArticleResponse>
        {
            public AddOrUpdateArticleHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateArticleResponse> Handle(AddOrUpdateArticleRequest request)
            {
                var entity = await _dataContext.Articles.FirstOrDefaultAsync(x => x.Id == request.Article.Id);
                                
                if (entity == null) _dataContext.Articles.Add(entity = new Article());
                
                if (await ArticleSlugExists(request.Article.Title.GenerateSlug(), request.Article.Id))
                    throw new ArticleSlugExistsException();

                entity.AuthorId = request.Article.AuthorId;
                entity.Title = request.Article.Title;
                entity.HtmlContent = request.Article.HtmlContent;
                entity.Slug = request.Article.Title.GenerateSlug();
                entity.IsPublished = request.Article.IsPublished;
                entity.Published = request.Article.Published;
                
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateArticleResponse();
            }

            public async Task<bool> ArticleSlugExists(string slug, int articleId)
                => (await _dataContext.Articles
                    .CountAsync(x => x.Slug == slug
                    && x.Id != articleId)) > 1;

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
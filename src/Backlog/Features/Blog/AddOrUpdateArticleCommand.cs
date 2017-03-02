using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Data.Models;
using System;

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
                var entity = await _dataContext.Articles
                    .FirstOrDefaultAsync(x => x.Id == request.Article.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Articles.Add(entity = new Article());
                entity.Title = request.Article.Title;
                entity.HtmlContent = request.Article.HtmlContent;
                entity.Slug = request.Article.Title.GenerateSlug();
                await _dataContext.SaveChangesAsync().ContinueWith(x =>
                {

                    var a = x;
                });
                return new AddOrUpdateArticleResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

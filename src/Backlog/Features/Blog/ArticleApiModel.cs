using Backlog.Data.Models;

namespace Backlog.Features.Blog
{
    public class ArticleApiModel
    {        
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }

        public static TModel FromArticle<TModel>(Article article) where
            TModel : ArticleApiModel, new()
        {
            var model = new TModel();
            model.Id = article.Id;
            model.Slug = article.Slug;
            model.Title = article.Title;
            model.HtmlContent = article.HtmlContent;
            return model;
        }

        public static ArticleApiModel FromArticle(Article article)
            => FromArticle<ArticleApiModel>(article);
    }
}
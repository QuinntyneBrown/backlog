using Backlog.Model;
using Backlog.Features.Categories;
using Backlog.Features.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Features.Blog
{
    public class ArticleApiModel
    {        
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? Published { get; set; }
        public AuthorApiModel Author { get; set; }
        public ICollection<TagApiModel> Tags { get; set; } = new HashSet<TagApiModel>();
        public ICollection<CategoryApiModel> MyProperty { get; set; }

        public static TModel FromArticle<TModel>(Article article) where
            TModel : ArticleApiModel, new()
        {
            var model = new TModel();
            model.Id = article.Id;
            model.AuthorId = article.AuthorId;
            model.Slug = article.Slug;
            model.Title = article.Title;
            model.HtmlContent = article.HtmlContent;
            model.Published = article.Published;
            model.Author = AuthorApiModel.FromAuthor(article.Author);
            model.Tags = article.Tags.Select(t => TagApiModel.FromTag(t)).ToList();
            return model;
        }

        public static ArticleApiModel FromArticle(Article article)
            => FromArticle<ArticleApiModel>(article);
    }
}
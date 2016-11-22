using System;
using System.Collections.Generic;

namespace Backlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; }
        public string Slug { get; set; } 
        public string HtmlContent { get; set; }
        public string HtmlExcerpt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Created { get; set; }

        public ICollection<StoryArticle> StoryArticles { get; set; } = new HashSet<StoryArticle>();
        public ICollection<ArticleSnapShot> ArticleSnapShots { get; set; } = new HashSet<ArticleSnapShot>();
    }
}

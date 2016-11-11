using System;
using System.Collections.Generic;

namespace Backlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Slug { get; set; }
        public string HtmlContent { get; set; }
        public string HtmlExcerpt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Created { get; set; }

        public ICollection<ArticleSnapShot> ArticleSnapShots { get; set; } = new HashSet<ArticleSnapShot>();
    }
}

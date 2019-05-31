using System;
using System.Collections.Generic;


namespace Backlog.Domain.Models
{
    
    public class StoryArticle
    {
        public Guid StoryArticleId { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid? StoryId { get; set; }
        public Article Article { get; set; }
        public Story Story { get; set; }
        
    }
}

using System.Collections.Generic;


namespace Backlog.Core.Models
{
    
    public class StoryArticle
    {
        public Guid Id { get; set; }
        public int? ArticleId { get; set; }
        public int? StoryId { get; set; }
        public Article Article { get; set; }
        public Story Story { get; set; }
        
    }
}

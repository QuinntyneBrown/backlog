using System.Collections.Generic;
using Backlog.Data.Helpers;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class StoryArticle
    {
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? StoryId { get; set; }
        public Article Article { get; set; }
        public Story Story { get; set; }
        public bool IsDeleted { get; set; }
    }
}

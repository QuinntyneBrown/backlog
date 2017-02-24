using System.Collections.Generic;

namespace Backlog.Data.Models
{
    public class EpicArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

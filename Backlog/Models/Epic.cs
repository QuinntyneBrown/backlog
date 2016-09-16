using System.Collections.Generic;

namespace Backlog.Models
{
    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public int? Priority { get; set; }
        public bool IsDeleted { get; set; }
    }
}

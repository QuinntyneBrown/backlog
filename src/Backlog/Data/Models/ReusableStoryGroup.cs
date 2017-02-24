using System.Collections.Generic;

namespace Backlog.Data.Models
{
    public class ReusableStoryGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public bool IsDeleted { get; set; }
    }
}

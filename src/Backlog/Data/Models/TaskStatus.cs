using System.Collections.Generic;

namespace Backlog.Data.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();   
        public bool IsDeleted { get; set; }
    }
}

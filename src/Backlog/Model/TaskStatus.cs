using System.Collections.Generic;
using Backlog.Data.Helpers;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();   
        public bool IsDeleted { get; set; }
    }
}

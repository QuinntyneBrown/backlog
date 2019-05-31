using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{    
    public class TaskStatus
    {
        public Guid TaskStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();           
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Domain.Models
{    
    public class Task
    {
        public int TaskId { get; set; }        
        public Guid? StoryId { get; set; }        
        [ForeignKey("TaskStatus")]
        public Guid? TaskStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Story Story { get; set; }
        public TaskStatus TaskStatus { get; set; }        
    }
}

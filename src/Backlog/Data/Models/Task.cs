using System;
using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Task: PrioritizableEntity
    {
        public override int Id { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        public int? TaskStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Story Story { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}

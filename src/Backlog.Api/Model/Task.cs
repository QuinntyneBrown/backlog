using System;
using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Task: PrioritizableEntity
    {
        public override int Id { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("TaskStatus")]
        public int? TaskStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Story Story { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

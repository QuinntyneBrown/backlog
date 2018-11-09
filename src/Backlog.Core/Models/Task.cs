using System;



namespace Backlog.Core.Models
{

    public class Task: PrioritizableEntity
    {
        public override int Id { get; set; }
        
        public int? StoryId { get; set; }
        
        public int? TenantId { get; set; }
        
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

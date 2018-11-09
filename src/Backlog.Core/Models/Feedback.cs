using System;



namespace Backlog.Core.Models
{

    public class Feedback
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

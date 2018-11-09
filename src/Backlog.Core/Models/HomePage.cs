using System;
using System.Collections.Generic;






namespace Backlog.Core.Models
{

    public class HomePage: ILoggable
    {
        public int Id { get; set; }
		
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<Link> Links { get; set; } = new HashSet<Link>();
        public string Title { get; set; }
        public string AvatarImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
		public DateTime LastModifiedOn { get; set; }
		public string CreatedBy { get; set; } 
		public string LastModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}

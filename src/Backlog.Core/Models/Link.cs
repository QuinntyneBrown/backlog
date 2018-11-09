using System;
using System.Collections.Generic;






namespace Backlog.Core.Models
{

    public class Link: ILoggable
    {
        public int Id { get; set; }
        
		
        public int? TenantId { get; set; }

        public string Url { get; set; }
        public string DisplayText { get; set; }

        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

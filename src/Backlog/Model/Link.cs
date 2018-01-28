using System;
using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Backlog.Constants;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Link: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
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

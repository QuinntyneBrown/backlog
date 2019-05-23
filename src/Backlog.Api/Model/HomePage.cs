using System;
using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Backlog.Constants;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class HomePage: ILoggable
    {
        public int Id { get; set; }
		[ForeignKey("Tenant")]
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

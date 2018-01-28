using System;
using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Backlog.Constants;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class SocialMediaAccount: ILoggable
    {
        public int Id { get; set; }        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }        
        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [Index("SocialMediaAccountNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(255)]		   
		public string Name { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
		public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}
using Backlog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Backlog.Constants;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Dashboard: ILoggable
    {
        public int Id { get; set; }
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public bool IsDefault { get; set; }
        [Index("DashboardNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(MaxStringLength)]		   
		public string Name { get; set; }
        public ICollection<DashboardTile> DashboardTiles { get; set; } = new HashSet<DashboardTile>();        
        public DateTime CreatedOn { get; set; }       
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
		public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual User User { get; set; }
    }
}

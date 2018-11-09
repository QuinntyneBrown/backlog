using System;
using System.Collections.Generic;

namespace Backlog.Core.Models
{

    public class Dashboard: ILoggable, ISoftDeletable
    {
        public int Id { get; set; }		
        public int? TenantId { get; set; }        
        public int? UserId { get; set; }
        public bool IsDefault { get; set; }        
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

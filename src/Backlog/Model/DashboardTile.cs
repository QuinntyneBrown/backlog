using System;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class DashboardTile: ILoggable
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
        [ForeignKey("Dashboard")]
        public int? DashboardId { get; set; }

        [ForeignKey("Tile")]
        public int? TileId { get; set; }

        public int Width { get; set; } = 1;

        public int Height { get; set; } = 1;

        public int Top { get; set; } = 1;

        public int Left { get; set; } = 1;

        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }

        public virtual Dashboard Dashboard { get; set; }

        public virtual Tile Tile { get; set; }
    }
}

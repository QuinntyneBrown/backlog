using System;

namespace Backlog.Domain.Models
{
    
    public class Tile        
    {
        public Guid TileId { get; set; }       
		public string Name { get; set; }        
		public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
    }
}

using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{
    
    public class HomePage
    {
        public Guid HomePageId { get; set; }		
        public string Name { get; set; }
        public ICollection<Link> Links { get; set; } = new HashSet<Link>();
        public string Title { get; set; }
        public string AvatarImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
		public DateTime LastModifiedOn { get; set; }
		public string CreatedBy { get; set; } 
		public string LastModifiedBy { get; set; }		
    }
}

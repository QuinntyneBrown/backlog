using System;

namespace Backlog.Domain.Models
{
    public class Link
    {
        public Guid LinkId { get; set; }        
        public string Url { get; set; }
        public string DisplayText { get; set; }
        public DateTime CreatedOn { get; set; }        
		public DateTime LastModifiedOn { get; set; }        
		public string CreatedBy { get; set; }        
		public string LastModifiedBy { get; set; }        
    }
}

using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{
    
    public class ReusableStoryGroup
    {
        public Guid ReusableStoryGroupId { get; set; }       
        public string Name { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();        
    }
}

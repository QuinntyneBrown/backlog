using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class ReusableStoryGroup
    {
        public Guid Id { get; set; }
        
        
        public string Name { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        

        
    }
}

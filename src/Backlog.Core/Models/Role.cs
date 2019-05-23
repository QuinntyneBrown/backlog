using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class Role
    {
        public Guid Id { get; set; }
        
        
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; } = new HashSet<User>();

        
    }
}

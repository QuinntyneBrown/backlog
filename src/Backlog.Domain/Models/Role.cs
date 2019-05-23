using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Domain.Models
{
    
    public class Role
    {
        public Guid RoleId { get; set; }        
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}

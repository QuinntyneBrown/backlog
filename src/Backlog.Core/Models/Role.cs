using System.Collections.Generic;



namespace Backlog.Core.Models
{

    public class Role
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public virtual Tenant Tenant { get; set; }
    }
}

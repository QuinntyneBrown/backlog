using System.Collections.Generic;



namespace Backlog.Core.Models
{

    public class Template
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Brand> Brands { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

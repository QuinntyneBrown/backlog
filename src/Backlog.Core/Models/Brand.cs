using System.Collections.Generic;

namespace Backlog.Core.Models
{

    public class Brand
    {
        public int Id { get; set; }        
        public int? TenantId { get; set; }        
        public int? TemplateId { get; set; }
        public Template Template { get; set; }
        public string Name { get; set; }
        public ICollection<BrandOwner> BrandOwners { get; set; } = new HashSet<BrandOwner>();
        public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();        
        public bool IsDeleted { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}

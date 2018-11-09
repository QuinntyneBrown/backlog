using System.Collections.Generic;



namespace Backlog.Core.Models
{

    public class BrandOwner
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        //[ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

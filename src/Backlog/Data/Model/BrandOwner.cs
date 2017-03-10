using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class BrandOwner
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class BrandFeature
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public int? BrandId { get; set; }
        public int? FeatureId { get; set; }
        public Brand Brand { get; set; }
        public Feature Feature { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

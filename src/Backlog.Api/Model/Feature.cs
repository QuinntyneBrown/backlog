using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Feature
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("FeatureCategory")]
        public int? FeatureCategoryId { get; set; }
        public FeatureCategory FeatureCategory { get; set; }
        public string Name { get; set; }
        public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

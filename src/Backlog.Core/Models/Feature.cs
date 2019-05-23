using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Core.Models
{
    
    public class Feature
    {
        public Guid Id { get; set; }
        
        
        [ForeignKey("FeatureCategory")]
        public int? FeatureCategoryId { get; set; }
        public FeatureCategory FeatureCategory { get; set; }
        public string Name { get; set; }
        public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();
        

        
    }
}

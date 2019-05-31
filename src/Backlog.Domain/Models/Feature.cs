using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models
{    
    public class Feature
    {
        public Guid FeatureId { get; set; }        
        [ForeignKey("FeatureCategory")]
        public Guid? FeatureCategoryId { get; set; }
        public FeatureCategory FeatureCategory { get; set; }
        public string Name { get; set; }
        public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();
        

        
    }
}

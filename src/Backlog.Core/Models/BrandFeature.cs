using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    public class BrandFeature
    {
        public int BrandFeatureId { get; set; }
        public int? BrandId { get; set; }
        public int? FeatureId { get; set; }
        public Brand Brand { get; set; }
        public Feature Feature { get; set; }

        
    }
}

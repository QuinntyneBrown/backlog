using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Domain.Models
{
    public class BrandFeature
    {
        public Guid BrandFeatureId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? FeatureId { get; set; }
        public Brand Brand { get; set; }
        public Feature Feature { get; set; }

        
    }
}

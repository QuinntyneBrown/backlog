using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class BrandFeature
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? FeatureId { get; set; }
        public Brand Brand { get; set; }
        public Feature Feature { get; set; }
    }
}

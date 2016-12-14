namespace Backlog.Models
{
    public class BrandFeature
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? FeatureId { get; set; }
        public Brand Brand { get; set; }
        public Feature Feature { get; set; }
    }
}

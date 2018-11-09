


namespace Backlog.Core.Models
{

    public class StoryDigitalAsset
    {
        public int Id { get; set; }
        
        public int? StoryId { get; set; }
        
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
        public Story Story { get; set; }
    }
}

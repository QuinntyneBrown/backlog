using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Core.Models
{
    
    public class StoryDigitalAsset
    {
        public Guid Id { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        [ForeignKey("DigitalAsset")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
        public Story Story { get; set; }
    }
}

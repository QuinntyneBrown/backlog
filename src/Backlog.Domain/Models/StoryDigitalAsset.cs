using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models
{
    
    public class StoryDigitalAsset
    {
        public Guid StoryDigitalAssetId { get; set; }
        [ForeignKey("Story")]
        public Guid? StoryId { get; set; }
        [ForeignKey("DigitalAsset")]
        public Guid? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
        public Story Story { get; set; }
    }
}

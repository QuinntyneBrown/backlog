using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class StoryDigitalAsset
    {
        public int Id { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        [ForeignKey("DigitalAsset")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
        public Story Story { get; set; }
    }
}

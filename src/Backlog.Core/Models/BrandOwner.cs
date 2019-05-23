using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    public class BrandOwner
    {
        public int BrandOwnerId { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }                
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [ForeignKey("Template")]
        public int? TemplateId { get; set; }
        public Template Template { get; set; }
        public string Name { get; set; }
        public ICollection<BrandOwner> BrandOwners { get; set; } = new HashSet<BrandOwner>();
        public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();        
        public bool IsDeleted { get; set; }
    }
}

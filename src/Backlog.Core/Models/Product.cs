using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class Product
    {
        public Guid Id { get; set; }
        
        
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Epic> Epics { get; set; } = new HashSet<Epic>();
        public ICollection<ProductSprint> ProductSprints { get; set; } = new HashSet<ProductSprint>();
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        
        
    }
}

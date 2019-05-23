
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class Category
    {
        public Guid Id { get; set; }
        
        
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        
        
    }
}

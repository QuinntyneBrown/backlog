using System;
using System.Collections.Generic;

namespace Backlog.Domain.Models
{    
    public class Category
    {
        public Guid CategoryId { get; set; }       
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();       
    }
}

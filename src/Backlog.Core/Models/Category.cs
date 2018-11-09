
using System.Collections.Generic;


namespace Backlog.Core.Models
{

    public class Category
    {
        public int Id { get; set; }
        
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual Tenant Tenant { get; set; }
        public bool IsDeleted { get; set; }
    }
}

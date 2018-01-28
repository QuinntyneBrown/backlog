using Backlog.Data.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Category
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual Tenant Tenant { get; set; }
        public bool IsDeleted { get; set; }
    }
}

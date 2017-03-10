using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class ProductSprint
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

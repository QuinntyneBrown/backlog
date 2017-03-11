using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Tag
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();

        public virtual Tenant Tenant { get; set; }
    }
}

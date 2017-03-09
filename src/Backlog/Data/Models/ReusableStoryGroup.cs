using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class ReusableStoryGroup
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

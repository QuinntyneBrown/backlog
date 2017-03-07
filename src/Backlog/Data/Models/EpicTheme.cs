using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class EpicTheme
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("Epic")]
        public int? EpicId { get; set; }
        [ForeignKey("Theme")]
        public int? ThemeId { get; set; }
        public Epic Epic { get; set; }
        public Theme Theme { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}

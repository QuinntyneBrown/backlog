using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Theme
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
        public ICollection<EpicTheme> EpicTheme { get; set; } = new HashSet<EpicTheme>();
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

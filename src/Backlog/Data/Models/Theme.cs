using System.Collections.Generic;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
        public ICollection<EpicTheme> EpicTheme { get; set; } = new HashSet<EpicTheme>();
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}

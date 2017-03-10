using System.Collections.Generic;
using Backlog.Data.Helpers;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class StoryTheme
    {
        public int Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public int? ThemeId { get; set; }
        public Theme Theme { get; set; }
        public bool IsDeleted { get; set; }
    }
}

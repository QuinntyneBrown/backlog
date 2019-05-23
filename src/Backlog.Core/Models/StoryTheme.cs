using System.Collections.Generic;


namespace Backlog.Core.Models
{
    
    public class StoryTheme
    {
        public Guid Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public int? ThemeId { get; set; }
        public Theme Theme { get; set; }
        
    }
}

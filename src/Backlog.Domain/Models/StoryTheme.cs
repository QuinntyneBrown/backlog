using System;
using System.Collections.Generic;


namespace Backlog.Domain.Models
{    
    public class StoryTheme
    {
        public Guid StoryThemeId { get; set; }
        public Guid? StoryId { get; set; }
        public Story Story { get; set; }
        public Guid? ThemeId { get; set; }
        public Theme Theme { get; set; }
        
    }
}

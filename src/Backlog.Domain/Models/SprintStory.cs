using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models
{
    
    public class SprintStory
    {
        public Guid SprintStoryId { get; set; }
        [ForeignKey("Sprint")]
        public Guid? SprintId { get; set; }
        [ForeignKey("Story")]
        public Guid? StoryId { get; set; }
        public Sprint Sprint { get; set; }
        public Story Story { get; set; }
        public string Name { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Core.Models
{
    
    public class SprintStory
    {
        public Guid Id { get; set; }
        [ForeignKey("Sprint")]
        public int? SprintId { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        public Sprint Sprint { get; set; }
        public Story Story { get; set; }
        public string Name { get; set; }
        
    }
}

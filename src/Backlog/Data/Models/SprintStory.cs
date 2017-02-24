using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Models
{
    public class SprintStory
    {
        public int Id { get; set; }
        [ForeignKey("Sprint")]
        public int? SprintId { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        public Sprint Sprint { get; set; }
        public Story Story { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

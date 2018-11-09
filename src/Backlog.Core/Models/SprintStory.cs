


namespace Backlog.Core.Models
{

    public class SprintStory
    {
        public int Id { get; set; }
        //[ForeignKey("Sprint")]
        public int? SprintId { get; set; }
        
        public int? StoryId { get; set; }
        public Sprint Sprint { get; set; }
        public Story Story { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

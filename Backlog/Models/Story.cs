using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Models
{
    public class Story
    {
        public int Id { get; set; }
        [ForeignKey("Epic")]
        public int? EpicId { get; set; }
        public int? ReusableStoryGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsReusable { get; set; }
        public bool IsDeleted { get; set; }
        public int? Priority { get; set; } = 0;
        public ReusableStoryGroup ReusableStoryGroup { get; set; }
        public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
        public ICollection<StoryDigitalAsset> StoryDigitalAssets { get; set; } = new HashSet<StoryDigitalAsset>();
        public Epic Epic { get; set; }
    }
}

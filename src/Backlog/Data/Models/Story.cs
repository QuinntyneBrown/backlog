using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Story: PrioritizableEntity
    {
        public override int Id { get; set; }
        [ForeignKey("Epic")]
        public int? EpicId { get; set; }
        public int? ReusableStoryGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string Notes { get; set; }
        public int? Points { get; set; }
        public int? ArchitecturePoints { get; set; }
        public bool IsReusable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
        public ReusableStoryGroup ReusableStoryGroup { get; set; }
        public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
        public ICollection<StoryDigitalAsset> StoryDigitalAssets { get; set; } = new HashSet<StoryDigitalAsset>();
        public ICollection<StoryArticle> StoryArticles { get; set; } = new HashSet<StoryArticle>();
        public Epic Epic { get; set; }
    }
}

using System;
using System.Collections.Generic;



namespace Backlog.Core.Models
{

    public class Story: PrioritizableEntity, ILoggable
    {
        public override int Id { get; set; }
        
        public int? TenantId { get; set; }
        //[ForeignKey("Epic")]
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
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
        public ReusableStoryGroup ReusableStoryGroup { get; set; }
        public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
        public ICollection<StoryDigitalAsset> StoryDigitalAssets { get; set; } = new HashSet<StoryDigitalAsset>();
        public ICollection<StoryArticle> StoryArticles { get; set; } = new HashSet<StoryArticle>();
        public Epic Epic { get; set; }
        public virtual Tenant Tenant { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
    }
}

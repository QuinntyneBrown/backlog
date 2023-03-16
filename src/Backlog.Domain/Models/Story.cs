using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class Story
{
    public Guid StoryId { get; set; }

    [ForeignKey("Epic")]
    public Guid? EpicId { get; set; }
    public Guid? ReusableStoryGroupId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string AcceptanceCriteria { get; set; }
    public string Notes { get; set; }
    public Guid? Points { get; set; }
    public Guid? ArchitecturePoints { get; set; }
    public bool IsReusable { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    public ReusableStoryGroup ReusableStoryGroup { get; set; }
    public ICollection<StoryTheme> StoryThemes { get; set; } = new HashSet<StoryTheme>();
    public ICollection<StoryDigitalAsset> StoryDigitalAssets { get; set; } = new HashSet<StoryDigitalAsset>();
    public ICollection<StoryArticle> StoryArticles { get; set; } = new HashSet<StoryArticle>();
    public Epic Epic { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string CreatedBy { get; set; }
    public string LastModifiedBy { get; set; }
}

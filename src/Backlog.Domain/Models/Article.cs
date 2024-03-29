using System;
using System.Collections.Generic;


namespace Backlog.Domain.Models;

public class Article
{
    public Guid ArticleId { get; set; }                        
    public Guid? AuthorId { get; set; }        
    public string Title { get; set; }        
    public string Slug { get; set; } 
    public string HtmlContent { get; set; }
    public string HtmlExcerpt { get; set; }        
    public bool IsPublished { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime? Published { get; set; }
    public DateTime? Created { get; set; }
    public ICollection<StoryArticle> StoryArticles { get; set; } = new HashSet<StoryArticle>();
    public ICollection<ArticleSnapShot> ArticleSnapShots { get; set; } = new HashSet<ArticleSnapShot>();
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string CreatedBy { get; set; }
    public string LastModifiedBy { get; set; }
    public virtual Author Author { get; set; }
}

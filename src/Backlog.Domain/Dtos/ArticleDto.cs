using Backlog.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Backlog.Domain.Dtos
{
    public class ArticleDtoValidator: AbstractValidator<ArticleDto>
    {
        public ArticleDtoValidator()
        {
            RuleFor(x => x.ArticleId).NotNull();
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Author).SetValidator(new AuthorDtoValidator());
            RuleForEach(x => x.Tags).SetValidator(new TagDtoValidator());
            RuleForEach(x => x.Categories).SetValidator(new CategoryDtoValidator());
        }
    }

    public class ArticleDto
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
        public ICollection<StoryArticleDto> StoryArticles { get; set; } = new HashSet<StoryArticleDto>();
        public ICollection<ArticleSnapShotDto> ArticleSnapShots { get; set; } = new HashSet<ArticleSnapShotDto>();
        public ICollection<TagDto> Tags { get; set; } = new HashSet<TagDto>();
        public ICollection<CategoryDto> Categories { get; set; } = new HashSet<CategoryDto>();
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual AuthorDto Author { get; set; }
    }

    public static class ArticleExtensions
    {        
        public static ArticleDto ToDto(this Article article)
            => new ArticleDto
            {
                ArticleId = article.ArticleId,
                Title = article.Title
            };
    }
}

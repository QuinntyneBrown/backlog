using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class StoryArticleDtoValidator: AbstractValidator<StoryArticleDto>
{
    public StoryArticleDtoValidator()
    {
        RuleFor(x => x.StoryArticleId).NotNull();
    }
}

public class StoryArticleDto
{        
    public Guid StoryArticleId { get; set; }
}

public static class StoryArticleExtensions
{        
    public static StoryArticleDto ToDto(this StoryArticle storyArticle)
        => new StoryArticleDto
        {
            StoryArticleId = storyArticle.StoryArticleId
        };
}

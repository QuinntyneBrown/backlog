using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class ArticleSnapShotDtoValidator: AbstractValidator<ArticleSnapShotDto>
{
    public ArticleSnapShotDtoValidator()
    {
        RuleFor(x => x.ArticleSnapShotId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class ArticleSnapShotDto
{        
    public Guid ArticleSnapShotId { get; set; }
    public string Name { get; set; }
}

public static class ArticleSnapShotExtensions
{        
    public static ArticleSnapShotDto ToDto(this ArticleSnapShot articleSnapShot)
        => new ArticleSnapShotDto
        {
            ArticleSnapShotId = articleSnapShot.ArticleSnapShotId
        };
}

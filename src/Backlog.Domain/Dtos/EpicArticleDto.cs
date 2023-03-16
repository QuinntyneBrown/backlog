using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class EpicArticleDtoValidator: AbstractValidator<EpicArticleDto>
{
    public EpicArticleDtoValidator()
    {
        RuleFor(x => x.EpicArticleId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class EpicArticleDto
{        
    public Guid EpicArticleId { get; set; }
    public string Name { get; set; }
}

public static class EpicArticleExtensions
{        
    public static EpicArticleDto ToDto(this EpicArticle epicArticle)
        => new EpicArticleDto
        {
            EpicArticleId = epicArticle.EpicArticleId,
            Name = epicArticle.Name
        };
}

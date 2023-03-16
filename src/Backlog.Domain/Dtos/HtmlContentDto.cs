using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class HtmlContentDtoValidator: AbstractValidator<HtmlContentDto>
{
    public HtmlContentDtoValidator()
    {
        RuleFor(x => x.HtmlContentId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class HtmlContentDto
{        
    public Guid HtmlContentId { get; set; }
    public string Name { get; set; }
}

public static class HtmlContentExtensions
{        
    public static HtmlContentDto ToDto(this HtmlContent htmlContent)
        => new HtmlContentDto
        {
            HtmlContentId = htmlContent.HtmlContentId,
            Name = htmlContent.Name
        };
}

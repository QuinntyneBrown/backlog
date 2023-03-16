using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class LinkDtoValidator: AbstractValidator<LinkDto>
{
    public LinkDtoValidator()
    {
        RuleFor(x => x.LinkId).NotNull();
    }
}

public class LinkDto
{        
    public Guid LinkId { get; set; }
}

public static class LinkExtensions
{        
    public static LinkDto ToDto(this Link link)
        => new LinkDto
        {
            LinkId = link.LinkId
        };
}

using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class TagDtoValidator: AbstractValidator<TagDto>
{
    public TagDtoValidator()
    {
        RuleFor(x => x.TagId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class TagDto
{        
    public Guid TagId { get; set; }
    public string Name { get; set; }
}

public static class TagExtensions
{        
    public static TagDto ToDto(this Tag tag)
        => new TagDto
        {
            TagId = tag.TagId,
            Name = tag.Name
        };
}

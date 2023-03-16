using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class EpicDtoValidator: AbstractValidator<EpicDto>
{
    public EpicDtoValidator()
    {
        RuleFor(x => x.EpicId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class EpicDto
{        
    public Guid EpicId { get; set; }
    public string Name { get; set; }
}

public static class EpicExtensions
{        
    public static EpicDto ToDto(this Epic epic)
        => new EpicDto
        {
            EpicId = epic.EpicId,
            Name = epic.Name
        };
}

using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class SprintDtoValidator: AbstractValidator<SprintDto>
    {
        public SprintDtoValidator()
        {
            RuleFor(x => x.SprintId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class SprintDto
    {        
        public Guid SprintId { get; set; }
        public string Name { get; set; }
    }

    public static class SprintExtensions
    {        
        public static SprintDto ToDto(this Sprint sprint)
            => new SprintDto
            {
                SprintId = sprint.SprintId,
                Name = sprint.Name
            };
    }
}

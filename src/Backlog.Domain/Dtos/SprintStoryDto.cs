using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class SprintStoryDtoValidator: AbstractValidator<SprintStoryDto>
    {
        public SprintStoryDtoValidator()
        {
            RuleFor(x => x.SprintStoryId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class SprintStoryDto
    {        
        public Guid SprintStoryId { get; set; }
        public string Name { get; set; }
    }

    public static class SprintStoryExtensions
    {        
        public static SprintStoryDto ToDto(this SprintStory sprintStory)
            => new SprintStoryDto
            {
                SprintStoryId = sprintStory.SprintStoryId,
                Name = sprintStory.Name
            };
    }
}

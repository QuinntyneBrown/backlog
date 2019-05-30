using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class StoryDtoValidator: AbstractValidator<StoryDto>
    {
        public StoryDtoValidator()
        {
            RuleFor(x => x.StoryId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class StoryDto
    {        
        public Guid StoryId { get; set; }
        public string Name { get; set; }
    }

    public static class StoryExtensions
    {        
        public static StoryDto ToDto(this Story story)
            => new StoryDto
            {
                StoryId = story.StoryId,
                Name = story.Name
            };
    }
}

using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class StoryThemeDtoValidator: AbstractValidator<StoryThemeDto>
    {
        public StoryThemeDtoValidator()
        {
            RuleFor(x => x.StoryThemeId).NotNull();
        }
    }

    public class StoryThemeDto
    {        
        public Guid StoryThemeId { get; set; }
        public string Name { get; set; }
    }

    public static class StoryThemeExtensions
    {        
        public static StoryThemeDto ToDto(this StoryTheme storyTheme)
            => new StoryThemeDto
            {
                StoryThemeId = storyTheme.StoryThemeId                
            };
    }
}

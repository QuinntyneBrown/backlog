using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ThemeDtoValidator: AbstractValidator<ThemeDto>
    {
        public ThemeDtoValidator()
        {
            RuleFor(x => x.ThemeId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ThemeDto
    {        
        public Guid ThemeId { get; set; }
        public string Name { get; set; }
    }

    public static class ThemeExtensions
    {        
        public static ThemeDto ToDto(this Theme theme)
            => new ThemeDto
            {
                ThemeId = theme.ThemeId,
                Name = theme.Name
            };
    }
}

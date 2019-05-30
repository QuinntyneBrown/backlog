using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class EpicThemeDtoValidator: AbstractValidator<EpicThemeDto>
    {
        public EpicThemeDtoValidator()
        {
            RuleFor(x => x.EpicThemeId).NotNull();
        }
    }

    public class EpicThemeDto
    {        
        public Guid EpicThemeId { get; set; }
    }

    public static class EpicThemeExtensions
    {        
        public static EpicThemeDto ToDto(this EpicTheme epicTheme)
            => new EpicThemeDto
            {
                EpicThemeId = epicTheme.EpicThemeId
            };
    }
}

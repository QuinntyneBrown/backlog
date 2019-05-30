using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class UserSettingsDtoValidator: AbstractValidator<UserSettingsDto>
    {
        public UserSettingsDtoValidator()
        {
            RuleFor(x => x.UserSettingsId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class UserSettingsDto
    {        
        public Guid UserSettingsId { get; set; }
        public string Name { get; set; }
    }

    public static class UserSettingsExtensions
    {        
        public static UserSettingsDto ToDto(this UserSettings userSettings)
            => new UserSettingsDto
            {
                UserSettingsId = userSettings.UserSettingsId,
                Name = userSettings.Name
            };
    }
}

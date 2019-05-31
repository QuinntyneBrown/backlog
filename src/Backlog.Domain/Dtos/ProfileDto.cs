using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ProfileDtoValidator: AbstractValidator<ProfileDto>
    {
        public ProfileDtoValidator()
        {
            RuleFor(x => x.ProfileId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ProfileDto
    {        
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
    }

    public static class ProfileExtensions
    {        
        public static ProfileDto ToDto(this Profile profile)
            => new ProfileDto
            {
                ProfileId = profile.ProfileId,
                Name = profile.Name
            };
    }
}

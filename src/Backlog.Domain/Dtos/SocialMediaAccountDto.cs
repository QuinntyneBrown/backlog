using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class SocialMediaAccountDtoValidator: AbstractValidator<SocialMediaAccountDto>
    {
        public SocialMediaAccountDtoValidator()
        {
            RuleFor(x => x.SocialMediaAccountId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class SocialMediaAccountDto
    {        
        public Guid SocialMediaAccountId { get; set; }
        public string Name { get; set; }
    }

    public static class SocialMediaAccountExtensions
    {        
        public static SocialMediaAccountDto ToDto(this SocialMediaAccount socialMediaAccount)
            => new SocialMediaAccountDto
            {
                SocialMediaAccountId = socialMediaAccount.SocialMediaAccountId,
                Name = socialMediaAccount.Name
            };
    }
}

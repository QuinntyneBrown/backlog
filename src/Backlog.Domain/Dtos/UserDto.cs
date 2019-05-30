using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class UserDto
    {        
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }

    public static class UserExtensions
    {        
        public static UserDto ToDto(this User user)
            => new UserDto
            {
                UserId = user.UserId,
                Name = user.Name
            };
    }
}

using Backlog.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Domain.Dtos
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Profile).NotNull();
            RuleForEach(x => x.Roles).SetValidator(new RoleDtoValidator());
            RuleFor(x => x.Profile).SetValidator(new ProfileDtoValidator());
        }
    }

    public class UserDto
    {        
        public Guid UserId { get; set; }
        public string Name { get; set; }        
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fullname { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
        public ProfileDto Profile { get; set; }
    }

    public static class UserExtensions
    {        
        public static UserDto ToDto(this User user)
            => new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Username = user.Username,
                Roles = user.Roles.Select(x => x.ToDto()).ToList()
            };
    }
}

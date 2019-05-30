using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class AuthorDtoValidator: AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(x => x.AuthorId).NotNull();
        }
    }

    public class AuthorDto
    {        
        public Guid AuthorId { get; set; }
    }

    public static class AuthorExtensions
    {        
        public static AuthorDto ToDto(this Author author)
            => new AuthorDto
            {
                AuthorId = author.AuthorId
            };
    }
}

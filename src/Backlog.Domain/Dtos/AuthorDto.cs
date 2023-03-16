using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

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
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string AvatarUrl { get; set; }
}

public static class AuthorExtensions
{        
    public static AuthorDto ToDto(this Author author)
        => new AuthorDto
        {
            AuthorId = author.AuthorId,
            Firstname = author.Firstname,
            Lastname = author.Lastname,
            AvatarUrl = author.AvatarUrl
        };
}

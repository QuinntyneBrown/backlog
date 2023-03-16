using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class HomePageDtoValidator: AbstractValidator<HomePageDto>
{
    public HomePageDtoValidator()
    {
        RuleFor(x => x.HomePageId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class HomePageDto
{        
    public Guid HomePageId { get; set; }
    public string Name { get; set; }
}

public static class HomePageExtensions
{        
    public static HomePageDto ToDto(this HomePage homePage)
        => new HomePageDto
        {
            HomePageId = homePage.HomePageId,
            Name = homePage.Name
        };
}

using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class CategoryDtoValidator: AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.CategoryId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class CategoryDto
{        
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
}

public static class CategoryExtensions
{        
    public static CategoryDto ToDto(this Category category)
        => new CategoryDto
        {
            CategoryId = category.CategoryId,
            Name = category.Name
        };
}

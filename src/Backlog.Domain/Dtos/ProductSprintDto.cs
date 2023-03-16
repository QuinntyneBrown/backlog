using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class ProductSprintDtoValidator: AbstractValidator<ProductSprintDto>
{
    public ProductSprintDtoValidator()
    {
        RuleFor(x => x.ProductSprintId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class ProductSprintDto
{        
    public Guid ProductSprintId { get; set; }
    public string Name { get; set; }
}

public static class ProductSprintExtensions
{        
    public static ProductSprintDto ToDto(this ProductSprint productSprint)
        => new ProductSprintDto
        {
            ProductSprintId = productSprint.ProductSprintId,
            Name = productSprint.Name
        };
}

using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ProductDtoValidator: AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ProductDto
    {        
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }

    public static class ProductExtensions
    {        
        public static ProductDto ToDto(this Product product)
            => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name
            };
    }
}

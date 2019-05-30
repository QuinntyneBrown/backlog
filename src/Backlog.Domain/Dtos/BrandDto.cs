using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class BrandDtoValidator: AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.BrandId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class BrandDto
    {        
        public Guid BrandId { get; set; }
        public string Name { get; set; }
    }

    public static class BrandExtensions
    {        
        public static BrandDto ToDto(this Brand brand)
            => new BrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };
    }
}

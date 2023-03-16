using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class BrandOwnerDtoValidator: AbstractValidator<BrandOwnerDto>
{
    public BrandOwnerDtoValidator()
    {
        RuleFor(x => x.BrandOwnerId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class BrandOwnerDto
{        
    public Guid BrandOwnerId { get; set; }
    public string Name { get; set; }
}

public static class BrandOwnerExtensions
{        
    public static BrandOwnerDto ToDto(this BrandOwner brandOwner)
        => new BrandOwnerDto
        {
            BrandOwnerId = brandOwner.BrandOwnerId,
            Name = brandOwner.Name
        };
}

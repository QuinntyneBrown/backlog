using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class DigitalAssetDtoValidator: AbstractValidator<DigitalAssetDto>
{
    public DigitalAssetDtoValidator()
    {
        RuleFor(x => x.DigitalAssetId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class DigitalAssetDto
{        
    public Guid DigitalAssetId { get; set; }
    public string Name { get; set; }
}

public static class DigitalAssetExtensions
{        
    public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        => new DigitalAssetDto
        {
            DigitalAssetId = digitalAsset.DigitalAssetId,
            Name = digitalAsset.Name
        };
}

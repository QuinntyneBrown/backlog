using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class BrandFeatureDtoValidator: AbstractValidator<BrandFeatureDto>
    {
        public BrandFeatureDtoValidator()
        {
            RuleFor(x => x.BrandFeatureId).NotNull();
        }
    }

    public class BrandFeatureDto
    {        
        public Guid BrandFeatureId { get; set; }
    }

    public static class BrandFeatureExtensions
    {        
        public static BrandFeatureDto ToDto(this BrandFeature brandFeature)
            => new BrandFeatureDto
            {
                BrandFeatureId = brandFeature.BrandFeatureId,
            };
    }
}

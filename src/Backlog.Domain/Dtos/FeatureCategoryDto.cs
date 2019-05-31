using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class FeatureCategoryDtoValidator: AbstractValidator<FeatureCategoryDto>
    {
        public FeatureCategoryDtoValidator()
        {
            RuleFor(x => x.FeatureCategoryId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class FeatureCategoryDto
    {        
        public Guid FeatureCategoryId { get; set; }
        public string Name { get; set; }
    }

    public static class FeatureCategoryExtensions
    {        
        public static FeatureCategoryDto ToDto(this FeatureCategory featureCategory)
            => new FeatureCategoryDto
            {
                FeatureCategoryId = featureCategory.FeatureCategoryId,
                Name = featureCategory.Name
            };
    }
}

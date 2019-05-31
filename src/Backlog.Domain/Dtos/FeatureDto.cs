using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class FeatureDtoValidator: AbstractValidator<FeatureDto>
    {
        public FeatureDtoValidator()
        {
            RuleFor(x => x.FeatureId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class FeatureDto
    {        
        public Guid FeatureId { get; set; }
        public string Name { get; set; }
    }

    public static class FeatureExtensions
    {        
        public static FeatureDto ToDto(this Feature feature)
            => new FeatureDto
            {
                FeatureId = feature.FeatureId,
                Name = feature.Name
            };
    }
}

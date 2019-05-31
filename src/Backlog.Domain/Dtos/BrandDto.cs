using Backlog.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Domain.Dtos
{
    public class BrandDtoValidator: AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.BrandId).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleForEach(x => x.BrandOwners).SetValidator(new BrandOwnerDtoValidator());
            RuleForEach(x => x.BrandFeatures).SetValidator(new BrandFeatureDtoValidator());
        }
    }

    public class BrandDto
    {        
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public Guid? TemplateId { get; set; }
        public Template Template { get; set; }        
        public ICollection<BrandOwnerDto> BrandOwners { get; set; } = new HashSet<BrandOwnerDto>();
        public ICollection<BrandFeatureDto> BrandFeatures { get; set; } = new HashSet<BrandFeatureDto>();
    }

    public static class BrandExtensions
    {        
        public static BrandDto ToDto(this Brand brand)
            => new BrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                TemplateId = brand.TemplateId,
                Template = brand.Template,
                BrandFeatures = brand.BrandFeatures.Select(x => x.ToDto()).ToList(),
                BrandOwners = brand.BrandOwners.Select(x => x.ToDto()).ToList()
            };
    }
}

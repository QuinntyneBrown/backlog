using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class BrandTemplateDtoValidator: AbstractValidator<BrandTemplateDto>
    {
        public BrandTemplateDtoValidator()
        {
            RuleFor(x => x.BrandTemplateId).NotNull();
        }
    }

    public class BrandTemplateDto
    {        
        public Guid BrandTemplateId { get; set; }
    }

    public static class BrandTemplateExtensions
    {        
        public static BrandTemplateDto ToDto(this BrandTemplate brandTemplate)
            => new BrandTemplateDto
            {
                BrandTemplateId = brandTemplate.BrandTemplateId
            };
    }
}

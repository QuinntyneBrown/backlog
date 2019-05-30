using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class TemplateDtoValidator: AbstractValidator<TemplateDto>
    {
        public TemplateDtoValidator()
        {
            RuleFor(x => x.TemplateId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class TemplateDto
    {        
        public Guid TemplateId { get; set; }
        public string Name { get; set; }
    }

    public static class TemplateExtensions
    {        
        public static TemplateDto ToDto(this Template template)
            => new TemplateDto
            {
                TemplateId = template.TemplateId,
                Name = template.Name
            };
    }
}

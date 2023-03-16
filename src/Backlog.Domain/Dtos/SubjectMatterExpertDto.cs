using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class SubjectMatterExpertDtoValidator: AbstractValidator<SubjectMatterExpertDto>
{
    public SubjectMatterExpertDtoValidator()
    {
        RuleFor(x => x.SubjectMatterExpertId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class SubjectMatterExpertDto
{        
    public Guid SubjectMatterExpertId { get; set; }
    public string Name { get; set; }
}

public static class SubjectMatterExpertExtensions
{        
    public static SubjectMatterExpertDto ToDto(this SubjectMatterExpert subjectMatterExpert)
        => new SubjectMatterExpertDto
        {
            SubjectMatterExpertId = subjectMatterExpert.SubjectMatterExpertId,
            Name = subjectMatterExpert.Name
        };
}

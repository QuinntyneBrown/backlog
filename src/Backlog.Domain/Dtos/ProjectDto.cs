using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ProjectDtoValidator: AbstractValidator<ProjectDto>
    {
        public ProjectDtoValidator()
        {
            RuleFor(x => x.ProjectId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ProjectDto
    {        
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }

    public static class ProjectExtensions
    {        
        public static ProjectDto ToDto(this Project project)
            => new ProjectDto
            {
                ProjectId = project.ProjectId,
                Name = project.Name
            };
    }
}

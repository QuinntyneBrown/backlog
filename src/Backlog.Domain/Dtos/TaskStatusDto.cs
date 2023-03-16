using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class TaskStatusDtoValidator: AbstractValidator<TaskStatusDto>
{
    public TaskStatusDtoValidator()
    {
        RuleFor(x => x.TaskStatusId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class TaskStatusDto
{        
    public Guid TaskStatusId { get; set; }
    public string Name { get; set; }
}

public static class TaskStatusExtensions
{        
    public static TaskStatusDto ToDto(this TaskStatus taskStatus)
        => new TaskStatusDto
        {
            TaskStatusId = taskStatus.TaskStatusId,
            Name = taskStatus.Name
        };
}

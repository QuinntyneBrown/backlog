using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class TaskDtoValidator: AbstractValidator<TaskDto>
{
    public TaskDtoValidator()
    {
        RuleFor(x => x.TaskId).NotNull();
        RuleFor(x => x.Name).NotNull();            
        RuleFor(x => x.Story).NotNull();
    }
}

public class TaskDto
{        
    public Guid TaskId { get; set; }
    public Guid? StoryId { get; set; }        
    public Guid? TaskStatusId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public StoryDto Story { get; set; }
    public TaskStatusDto TaskStatus { get; set; }
}

public static class TaskExtensions
{        
    public static TaskDto ToDto(this Task task)
        => new TaskDto
        {
            TaskId = task.TaskId,
            Name = task.Name
        };
}

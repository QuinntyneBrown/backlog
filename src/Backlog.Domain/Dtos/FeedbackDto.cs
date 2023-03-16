using Backlog.Domain.Models;
using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class FeedbackDtoValidator: AbstractValidator<FeedbackDto>
{
    public FeedbackDtoValidator()
    {
        RuleFor(x => x.FeedbackId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class FeedbackDto
{        
    public Guid FeedbackId { get; set; }
    public string Name { get; set; }
}

public static class FeedbackExtensions
{        
    public static FeedbackDto ToDto(this Feedback feedback)
        => new FeedbackDto
        {
            FeedbackId = feedback.FeedbackId,
            Name = feedback.Name
        };
}

using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ReusableStoryGroupDtoValidator: AbstractValidator<ReusableStoryGroupDto>
    {
        public ReusableStoryGroupDtoValidator()
        {
            RuleFor(x => x.ReusableStoryGroupId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ReusableStoryGroupDto
    {        
        public Guid ReusableStoryGroupId { get; set; }
        public string Name { get; set; }
    }

    public static class ReusableStoryGroupExtensions
    {        
        public static ReusableStoryGroupDto ToDto(this ReusableStoryGroup reusableStoryGroup)
            => new ReusableStoryGroupDto
            {
                ReusableStoryGroupId = reusableStoryGroup.ReusableStoryGroupId,
                Name = reusableStoryGroup.Name
            };
    }
}

using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class AgileTeamDtoValidator: AbstractValidator<AgileTeamDto>
    {
        public AgileTeamDtoValidator()
        {
            RuleFor(x => x.AgileTeamId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class AgileTeamDto
    {        
        public Guid AgileTeamId { get; set; }
        public string Name { get; set; }
    }

    public static class AgileTeamExtensions
    {        
        public static AgileTeamDto ToDto(this AgileTeam agileTeam)
            => new AgileTeamDto
            {
                AgileTeamId = agileTeam.AgileTeamId,
                Name = agileTeam.Name
            };
    }
}

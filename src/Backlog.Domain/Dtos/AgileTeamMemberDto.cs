using Backlog.Domain.Models;
using System;

namespace Backlog.Domain.Dtos
{
    public class AgileTeamMemberDto
    {        
        public Guid AgileTeamMemberId { get; set; }
        public string Name { get; set; }
    }

    public static class AgileTeamMemberExtensions
    {        
        public static AgileTeamMemberDto ToDto(this AgileTeamMember agileTeamMember)
            => new AgileTeamMemberDto
            {
                AgileTeamMemberId = agileTeamMember.AgileTeamMemberId,
                Name = agileTeamMember.Name
            };
    }
}

using System;

namespace Backlog.Core.Models
{
    public class AgileTeamMember
    {
        public Guid AgileTeamMemberId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}

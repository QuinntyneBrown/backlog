using System;

namespace Backlog.Core.Models
{
    public class AgileTeam
    {
        public Guid AgileTeamId { get; set; }        
        public string Name { get; set; }
        public bool IsDeleted { get; set; }        
    }
}

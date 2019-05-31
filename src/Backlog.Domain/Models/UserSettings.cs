using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Domain.Models
{
    
    public class UserSettings
    {        
        public Guid UserSettingsId { get; set; }
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool? IsKanbanEnabled { get; set; }
        public bool? IsTasksEnabled { get; set; }
        public bool? IsSpecsEnabled { get; set; }
        
    }
}

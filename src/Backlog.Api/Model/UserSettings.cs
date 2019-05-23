using System.ComponentModel.DataAnnotations.Schema;
using Backlog.Data.Helpers;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class UserSettings
    {
        [SoftDelete("IsDeleted")]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool? IsKanbanEnabled { get; set; }
        public bool? IsTasksEnabled { get; set; }
        public bool? IsSpecsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}




namespace Backlog.Core.Models
{

    public class UserSettings
    {
    
        public int Id { get; set; }
        //[ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool? IsKanbanEnabled { get; set; }
        public bool? IsTasksEnabled { get; set; }
        public bool? IsSpecsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}

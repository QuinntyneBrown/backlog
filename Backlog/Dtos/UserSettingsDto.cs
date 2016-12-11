namespace Backlog.Dtos
{
    public class UserSettingsDto
    {
        public UserSettingsDto(Backlog.Models.UserSettings entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            IsKanbanEnabled = entity.IsKanbanEnabled;
            IsSpecsEnabled = entity.IsSpecsEnabled;
            IsTasksEnabled = entity.IsTasksEnabled;

        }

        public UserSettingsDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsKanbanEnabled { get; set; }
        public bool? IsTasksEnabled { get; set; }
        public bool? IsSpecsEnabled { get; set; }
    }
}

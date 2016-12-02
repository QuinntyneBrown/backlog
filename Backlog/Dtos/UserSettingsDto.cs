namespace Backlog.Dtos
{
    public class UserSettingsDto
    {
        public UserSettingsDto(Backlog.Models.UserSettings entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public UserSettingsDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

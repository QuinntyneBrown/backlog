namespace Backlog.Dtos
{
    public class ThemeDto
    {
        public ThemeDto(Backlog.Models.Theme entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ThemeDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

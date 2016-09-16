namespace Backlog.Dtos
{
    public class StoryDto
    {
        public StoryDto(Backlog.Models.Story entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public StoryDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

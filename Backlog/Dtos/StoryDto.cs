namespace Backlog.Dtos
{
    public class StoryDto
    {
        public StoryDto(Backlog.Models.Story entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            EpicId = entity.EpicId;
        }

        public StoryDto()
        {
            
        }

        public int Id { get; set; }
        public int? EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EpicDto Epic { get; set; }
    }
}

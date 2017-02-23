namespace Backlog.Dtos
{
    public class ReusableStoryGroupDto
    {
        public ReusableStoryGroupDto(Backlog.Models.ReusableStoryGroup entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ReusableStoryGroupDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

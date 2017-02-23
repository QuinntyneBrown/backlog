namespace Backlog.Dtos
{
    public class SprintDto
    {
        public SprintDto(Backlog.Models.Sprint entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public SprintDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

namespace Backlog.Dtos
{
    public class EpicDto
    {
        public EpicDto(Backlog.Models.Epic entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public EpicDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

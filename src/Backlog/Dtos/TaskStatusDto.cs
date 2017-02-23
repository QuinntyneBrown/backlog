namespace Backlog.Dtos
{
    public class TaskStatusDto
    {
        public TaskStatusDto(Backlog.Models.TaskStatus entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public TaskStatusDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

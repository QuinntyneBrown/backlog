namespace Backlog.Dtos
{
    public class TemplateDto
    {
        public TemplateDto(Backlog.Models.Template entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public TemplateDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

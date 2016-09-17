namespace Backlog.Dtos
{
    public class HtmlContentDto
    {
        public HtmlContentDto(Backlog.Models.HtmlContent entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public HtmlContentDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

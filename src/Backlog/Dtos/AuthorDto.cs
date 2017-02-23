namespace Backlog.Dtos
{
    public class AuthorDto
    {
        public AuthorDto(Backlog.Models.Author entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public AuthorDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

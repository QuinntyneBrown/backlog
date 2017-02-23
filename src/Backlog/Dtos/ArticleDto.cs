namespace Backlog.Dtos
{
    public class ArticleDto
    {
        public ArticleDto(Backlog.Models.Article entity)
        {
            Id = entity.Id;
            Slug = entity.Slug;
            Title = entity.Title;
            HtmlContent = entity.HtmlContent;
        }

        public ArticleDto()
        {
            
        }

        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}

namespace Backlog.Dtos
{
    public class ArticleDto
    {
        public ArticleDto(Backlog.Models.Article entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.HtmlContent = entity.HtmlContent;
        }

        public ArticleDto()
        {
            
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}

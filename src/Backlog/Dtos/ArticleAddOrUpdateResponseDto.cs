namespace Backlog.Dtos
{
    public class ArticleAddOrUpdateResponseDto: ArticleDto
    {
        public ArticleAddOrUpdateResponseDto(Backlog.Models.Article entity)
            :base(entity)
        {

        }
    }
}

namespace Backlog.Dtos
{
    public class AuthorAddOrUpdateResponseDto: AuthorDto
    {
        public AuthorAddOrUpdateResponseDto(Backlog.Models.Author entity)
            :base(entity)
        {

        }
    }
}

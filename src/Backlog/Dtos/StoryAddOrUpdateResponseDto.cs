namespace Backlog.Dtos
{
    public class StoryAddOrUpdateResponseDto: StoryDto
    {
        public StoryAddOrUpdateResponseDto(Backlog.Models.Story entity)
            :base(entity)
        {

        }
    }
}

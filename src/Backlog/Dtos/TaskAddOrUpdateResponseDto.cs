namespace Backlog.Dtos
{
    public class TaskAddOrUpdateResponseDto: TaskDto
    {
        public TaskAddOrUpdateResponseDto(Backlog.Models.Task entity)
            :base(entity)
        {

        }
    }
}

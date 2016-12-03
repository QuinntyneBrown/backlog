namespace Backlog.Dtos
{
    public class TaskStatusAddOrUpdateResponseDto: TaskStatusDto
    {
        public TaskStatusAddOrUpdateResponseDto(Backlog.Models.TaskStatus entity)
            :base(entity)
        {

        }
    }
}

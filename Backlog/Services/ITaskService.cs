using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface ITaskService
    {
        TaskAddOrUpdateResponseDto AddOrUpdate(TaskAddOrUpdateRequestDto request);
        ICollection<TaskDto> Get();
        ICollection<TaskStatusDto> GetTaskStatuses();
        TaskDto GetById(int id);
        dynamic Remove(int id);
        ICollection<TaskDto> GetByStoryId(int storyId);
    }
}

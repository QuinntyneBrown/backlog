using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface ITaskService
    {
        TaskAddOrUpdateResponseDto AddOrUpdate(TaskAddOrUpdateRequestDto request);
        ICollection<TaskDto> Get();
        TaskDto GetById(int id);
        dynamic Remove(int id);
    }
}

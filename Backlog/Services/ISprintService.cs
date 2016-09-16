using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface ISprintService
    {
        SprintAddOrUpdateResponseDto AddOrUpdate(SprintAddOrUpdateRequestDto request);
        ICollection<SprintDto> Get();
        SprintDto GetById(int id);
        dynamic Remove(int id);
    }
}

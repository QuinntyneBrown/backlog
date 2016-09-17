using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IEpicService
    {
        EpicAddOrUpdateResponseDto AddOrUpdate(EpicAddOrUpdateRequestDto request);
        ICollection<EpicDto> Get();
        EpicDto GetById(int id);
        dynamic Remove(int id);
        ICollection<EpicDto> IncrementPriority(int id);
        ICollection<EpicDto> DecrementPriority(int id);
    }
}

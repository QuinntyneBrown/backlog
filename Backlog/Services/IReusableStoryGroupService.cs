using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IReusableStoryGroupService
    {
        ReusableStoryGroupAddOrUpdateResponseDto AddOrUpdate(ReusableStoryGroupAddOrUpdateRequestDto request);
        ICollection<ReusableStoryGroupDto> Get();
        ReusableStoryGroupDto GetById(int id);
        dynamic Remove(int id);
    }
}

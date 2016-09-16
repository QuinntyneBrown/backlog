using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IStoryService
    {
        StoryAddOrUpdateResponseDto AddOrUpdate(StoryAddOrUpdateRequestDto request);
        ICollection<StoryDto> Get();
        StoryDto GetById(int id);
        dynamic Remove(int id);
    }
}

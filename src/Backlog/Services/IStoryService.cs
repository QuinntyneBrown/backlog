using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IStoryService
    {
        StoryAddOrUpdateResponseDto AddOrUpdate(StoryAddOrUpdateRequestDto request);
        ICollection<StoryDto> Get();
        ICollection<StoryDto> GetReusableStories();
        StoryDto GetById(int id);
        dynamic Remove(int id);
        ICollection<StoryDto> IncrementPriority(int id);
        ICollection<StoryDto> DecrementPriority(int id);
    }
}

using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface ITagService
    {
        TagAddOrUpdateResponseDto AddOrUpdate(TagAddOrUpdateRequestDto request);
        ICollection<TagDto> Get();
        TagDto GetById(int id);
        dynamic Remove(int id);
    }
}

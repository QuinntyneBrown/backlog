using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IHtmlContentService
    {
        HtmlContentAddOrUpdateResponseDto AddOrUpdate(HtmlContentAddOrUpdateRequestDto request);
        ICollection<HtmlContentDto> Get();
        HtmlContentDto GetById(int id);
        dynamic Remove(int id);
    }
}

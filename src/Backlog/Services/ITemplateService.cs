using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface ITemplateService
    {
        TemplateAddOrUpdateResponseDto AddOrUpdate(TemplateAddOrUpdateRequestDto request);
        ICollection<TemplateDto> Get();
        TemplateDto GetById(int id);
        dynamic Remove(int id);
    }
}

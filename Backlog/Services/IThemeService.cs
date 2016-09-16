using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IThemeService
    {
        ThemeAddOrUpdateResponseDto AddOrUpdate(ThemeAddOrUpdateRequestDto request);
        ICollection<ThemeDto> Get();
        ThemeDto GetById(int id);
        dynamic Remove(int id);
    }
}

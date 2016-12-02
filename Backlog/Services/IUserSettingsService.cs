using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IUserSettingsService
    {
        UserSettingsAddOrUpdateResponseDto AddOrUpdate(UserSettingsAddOrUpdateRequestDto request);
        ICollection<UserSettingsDto> Get();
        UserSettingsDto GetById(int id);
        dynamic Remove(int id);
    }
}

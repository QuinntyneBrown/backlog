using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IAgileTeamService
    {
        AgileTeamAddOrUpdateResponseDto AddOrUpdate(AgileTeamAddOrUpdateRequestDto request);
        ICollection<AgileTeamDto> Get();
        AgileTeamDto GetById(int id);
        dynamic Remove(int id);
    }
}

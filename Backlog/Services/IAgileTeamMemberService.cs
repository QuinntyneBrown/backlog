using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IAgileTeamMemberService
    {
        AgileTeamMemberAddOrUpdateResponseDto AddOrUpdate(AgileTeamMemberAddOrUpdateRequestDto request);
        ICollection<AgileTeamMemberDto> Get();
        AgileTeamMemberDto GetById(int id);
        dynamic Remove(int id);
    }
}

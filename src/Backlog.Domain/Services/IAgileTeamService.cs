using Backlog.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backlog.Domain.Services;

public interface IAgileTeamService
{
    Task<AgileTeamDto> GetByIdAsync(Guid id);
    Task<AgileTeamDto> InsertAsync(AgileTeamDto dto);
    Task<AgileTeamDto> UpdateAsync(AgileTeamDto dto);
    Task<IEnumerable<AgileTeamDto>> GetAllAsync();
    Task<int> RemoveAsync(AgileTeamDto dto);
}

using Backlog.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Backlog.Domain.Services
{
    public interface IAgileTeamService
    {
        Task<AgileTeam> GetByIdAsync(Guid id);
    }
}
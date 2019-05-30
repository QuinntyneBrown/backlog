using Backlog.Domain.DataAccess;
using Backlog.Domain.Dtos;
using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backlog.Domain.Services
{
    public interface IAgileTeamService
    {
        Task<AgileTeamDto> GetByIdAsync(Guid id);
        Task<AgileTeamDto> InsertAsync(AgileTeamDto entity);
        Task<IEnumerable<AgileTeamDto>> GetAllAsync();
    }

    public class AgileTeamService: IAgileTeamService
    {
        private readonly IAppDbContext _context;
        public AgileTeamService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AgileTeamDto> GetByIdAsync(Guid id)
        {
            return (await _context.AgileTeams.FindAsync(id)).ToDto();
        }

        public async Task<IEnumerable<AgileTeamDto>> GetAllAsync()
        {
            return (await _context.AgileTeams.ToListAsync())
                .Select(x => x.ToDto());
        }

        public async Task<AgileTeamDto> InsertAsync(AgileTeamDto agileTeam)
        {
            var result = await _context.AgileTeams.AddAsync(new AgileTeam
            {
                Name = agileTeam.Name
            });

            await _context.SaveChangesAsync();

            return result.Entity.ToDto();
        }

        public async Task<AgileTeamDto> UpdateAsync(AgileTeam entity)
        {
            var _entity = await GetByIdAsync(entity.AgileTeamId);

            _entity.Name = entity.Name;

            await _context.SaveChangesAsync();

            return _entity;
        }

        public async System.Threading.Tasks.Task DeleteAsync(AgileTeam entity)
        {
            _context.AgileTeams.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}

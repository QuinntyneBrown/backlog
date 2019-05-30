using Backlog.Domain.DataAccess;
using Backlog.Domain.Dtos;
using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backlog.Domain.Services
{
    public interface IAgileTeamService
    {
        Task<AgileTeamDto> GetByIdAsync(Guid id);
        Task<AgileTeamDto> InsertAsync(AgileTeamDto entity);
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

        public async Task<IEnumerable<AgileTeam>> GetAllAsync()
        {
            return await _context.AgileTeams.ToListAsync();
        }

        public async Task<AgileTeamDto> InsertAsync(AgileTeamDto agileTeam)
        {
            //await _context.AgileTeams.AddAsync(entity);

            //await _context.SaveChangesAsync();

            return agileTeam;
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

using Backlog.Domain.DataAccess;
using Backlog.Domain.Dtos;
using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backlog.Domain.Services;

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

    public async Task<AgileTeamDto> InsertAsync(AgileTeamDto dto)
    {
        var result = await _context.AgileTeams.AddAsync(new AgileTeam
        {
            Name = dto.Name
        });

        await _context.SaveChangesAsync();

        return result.Entity.ToDto();
    }

    public async Task<AgileTeamDto> UpdateAsync(AgileTeamDto dto)
    {
        var _entity = await GetByIdAsync(dto.AgileTeamId);

        _entity.Name = dto.Name;

        await _context.SaveChangesAsync();

        return _entity;
    }

    public async Task<int> RemoveAsync(AgileTeamDto dto)
    {
        var agileTeam = await _context.AgileTeams.FindAsync(dto.AgileTeamId);

        _context.AgileTeams.Remove(agileTeam);

        return await _context.SaveChangesAsync();
    }
}

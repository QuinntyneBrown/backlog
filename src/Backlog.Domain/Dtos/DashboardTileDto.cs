using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class DashboardTileDtoValidator: AbstractValidator<DashboardTileDto>
    {
        public DashboardTileDtoValidator()
        {
            RuleFor(x => x.DashboardTileId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class DashboardTileDto
    {        
        public Guid DashboardTileId { get; set; }
        public string Name { get; set; }
    }

    public static class DashboardTileExtensions
    {        
        public static DashboardTileDto ToDto(this DashboardTile dashboardTile)
            => new DashboardTileDto
            {
                DashboardTileId = dashboardTile.DashboardTileId,
                Name = dashboardTile.Name
            };
    }
}

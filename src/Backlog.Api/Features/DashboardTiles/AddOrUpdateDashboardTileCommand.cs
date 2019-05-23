using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.DashboardTiles
{
    public class AddOrUpdateDashboardTileCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public DashboardTileApiModel DashboardTile { get; set; }  
            public int UserId { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IBacklogContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.DashboardTiles
                    .Include(x => x.Tenant)
                    .Include(x => x.Dashboard)
                    .Include("Dashboard.DashboardTiles")
                    .SingleOrDefaultAsync(x => x.Id == request.DashboardTile.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                if (entity == null)
                {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    var dashboard = _context.Dashboards
                        .Include(x => x.DashboardTiles)
                        .Single(x => x.Id == request.DashboardTile.DashboardId.Value
                        && x.Tenant.UniqueId == request.TenantUniqueId);

                    _context.DashboardTiles.Add(entity = new DashboardTile() {TenantId = tenant.Id });

                    dashboard.DashboardTiles.Add(entity);
                }

                entity.TileId = request.DashboardTile.TileId;
                entity.Name = request.DashboardTile.Name;
                entity.Top = request.DashboardTile.Top;
                entity.Left = request.DashboardTile.Left;
                entity.Width = request.DashboardTile.Width;
                entity.Height = request.DashboardTile.Height;

                await _context.SaveChangesAsync(request.Username);
                
                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

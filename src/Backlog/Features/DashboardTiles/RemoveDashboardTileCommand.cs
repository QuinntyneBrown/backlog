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
    public class RemoveDashboardTileCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public int Id { get; set; }
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
                var dashboardTile = await _context.DashboardTiles.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                dashboardTile.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

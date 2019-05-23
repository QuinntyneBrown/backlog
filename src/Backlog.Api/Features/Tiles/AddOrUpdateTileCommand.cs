using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tiles
{
    public class AddOrUpdateTileCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public TileApiModel Tile { get; set; }            
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
                var entity = await _context.Tiles
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Tile.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Tiles.Add(entity = new Tile() { TenantId = tenant.Id });
                }

                entity.Name = request.Tile.Name;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

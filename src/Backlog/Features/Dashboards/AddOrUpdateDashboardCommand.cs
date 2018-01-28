using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Dashboards
{
    public class AddOrUpdateDashboardCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public DashboardApiModel Dashboard { get; set; }            
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
                var entity = await _context.Dashboards
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Dashboard.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Dashboards.Add(entity = new Dashboard() { TenantId = tenant.Id });
                }

                entity.Name = request.Dashboard.Name;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

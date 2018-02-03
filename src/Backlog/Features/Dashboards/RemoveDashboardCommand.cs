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
    public class RemoveDashboardCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
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
                var dashboard = await _context.Dashboards
                    .Include(x => x.Tenant)
                    .SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                _context.Dashboards.Remove(dashboard);
                await _context.SaveChangesAsync(request.Username);
                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.HomePages
{
    public class AddOrUpdateHomePageCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public HomePageApiModel HomePage { get; set; }            
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
                var entity = await _context.HomePages
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.HomePages.Add(entity = new HomePage() { TenantId = tenant.Id });
                }

                entity.AvatarImageUrl = request.HomePage.AvatarImageUrl;
                entity.Name = request.HomePage.Name;
                entity.Title = request.HomePage.Title;
                await _context.SaveChangesAsync(request.Username);

                return new Response();
            }

            private readonly IBacklogContext _context;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.HomePages
{
    public class GetHomePageByIdQuery
    {
        public class Request : BaseRequest, IRequest<Response> { 
            public int Id { get; set; }            
        }

        public class Response
        {
            public HomePageApiModel HomePage { get; set; } 
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    HomePage = HomePageApiModel.FromHomePage(await _context.HomePages
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

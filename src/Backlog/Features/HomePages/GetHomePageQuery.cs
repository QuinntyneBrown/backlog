using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;

namespace Backlog.Features.HomePages
{
    public class GetHomePageQuery
    {
        public class Request : BaseRequest, IRequest<Response> { }

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
                var homePage = await _cache.FromCacheOrServiceAsync(() => _context.HomePages
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Tenant.UniqueId == request.TenantUniqueId), 
                    HomePagesCacheKeyFactory.Get(request.TenantUniqueId));

                return new Response()
                {
                    HomePage = homePage == null ? null : HomePageApiModel.FromHomePage(homePage)
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

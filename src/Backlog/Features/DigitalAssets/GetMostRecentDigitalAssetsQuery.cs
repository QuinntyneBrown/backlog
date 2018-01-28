using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;

namespace Backlog.Features.DigitalAssets
{
    public class GetMostRecentDigitalAssetsQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            
        }

        public class Response
        {
            public ICollection<DigitalAssetApiModel> DigitalAssets { get; set; } = new HashSet<DigitalAssetApiModel>();
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
                var digitalAssets = await _context
                .DigitalAssets
                .Include(x => x.Tenant)
                .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                .Take(5)
                .ToListAsync();

                return new Response()
                {
                    DigitalAssets = digitalAssets.Select(x => DigitalAssetApiModel.FromDigitalAsset(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

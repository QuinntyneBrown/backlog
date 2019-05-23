using MediatR;
using Backlog.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;
using static Backlog.Features.DigitalAssets.Constants;
using Backlog.Features.Core;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetsQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<DigitalAssetApiModel> DigitalAssets { get; set; } = new HashSet<DigitalAssetApiModel>();
        }

        public class GetDigitalAssetsHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetDigitalAssetsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var digitalAssets = await _cache.FromCacheOrServiceAsync<List<DigitalAsset>>(() => _context
                .DigitalAssets
                .Include(x => x.Tenant)
                .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                .ToListAsync(), DigitalAssetsCacheKeyFactory.Get(request.TenantUniqueId));

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
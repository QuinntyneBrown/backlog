using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;
using System;
using System.IdentityModel.Tokens;
using Backlog.Features.Security;
using Backlog.Model;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetByUniqueIdQuery
    {
        public class Request : IRequest<Response>
        {
            public string UniqueId { get; set; }
            public string OAuthToken { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class Response
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class GetDigitalAssetByUniqueIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetDigitalAssetByUniqueIdHandler(BacklogContext context, ICache cache, Lazy<IAuthConfiguration> authConfiguration)
            {
                _context = context;
                _cache = cache;
                _authConfiguration = authConfiguration.Value;
            }

            public async Task<Response> Handle(Request request)
            {
                if(string.IsNullOrEmpty(request.OAuthToken))
                    return new Response()
                    {
                        DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _cache.FromCacheOrServiceAsync<DigitalAsset>(() => _context
                        .DigitalAssets
                        .Include(x => x.Tenant)
                        .SingleAsync(x => x.UniqueId.ToString() == request.UniqueId && x.IsSecure == false),DigitalAssetsCacheKeyFactory.GetByUniqueId(request.TenantUniqueId,request.UniqueId)))
                    };

                return new Response()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _context
                    .DigitalAssets
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.UniqueId.ToString() == request.UniqueId && x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
            protected readonly IAuthConfiguration _authConfiguration;
        }
    }
}

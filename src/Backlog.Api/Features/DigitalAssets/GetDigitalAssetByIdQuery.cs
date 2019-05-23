using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetByIdQuery
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public DigitalAssetApiModel DigitalAsset { get; set; } 
		}

        public class GetDigitalAssetByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetDigitalAssetByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var digitalAsset = await _context.DigitalAssets
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                return new Response()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(digitalAsset)
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

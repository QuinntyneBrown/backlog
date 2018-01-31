using MediatR;
using Backlog.Data;
using System.Threading.Tasks;
using Backlog.Features.Core;
using System.Data.Entity;

namespace Backlog.Features.DigitalAssets
{
    public class RemoveDigitalAssetCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveDigitalAssetHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveDigitalAssetHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var digitalAsset = await _context.DigitalAssets
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                digitalAsset.IsDeleted = true;

                await _context.SaveChangesAsync(request.Username);

                _cache.Remove(DigitalAssetsCacheKeyFactory.Get(request.TenantUniqueId));
                _cache.Remove(DigitalAssetsCacheKeyFactory.GetByUniqueId(request.TenantUniqueId, $"{digitalAsset.UniqueId}"));

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

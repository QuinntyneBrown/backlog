using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Features.Core;

namespace Backlog.Features.DigitalAssets
{
    public class RemoveDigitalAssetCommand
    {
        public class RemoveDigitalAssetRequest : IRequest<RemoveDigitalAssetResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveDigitalAssetResponse { }

        public class RemoveDigitalAssetHandler : IAsyncRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>
        {
            public RemoveDigitalAssetHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveDigitalAssetResponse> Handle(RemoveDigitalAssetRequest request)
            {
                var digitalAsset = await _dataContext.DigitalAssets.FindAsync(request.Id);
                digitalAsset.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveDigitalAssetResponse();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

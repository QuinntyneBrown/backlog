using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using System.Threading.Tasks;
using System.Data.Entity;
using Backlog.Features.Core;

namespace Backlog.Features.DigitalAssets
{
    public class AddOrUpdateDigitalAssetCommand
    {
        public class AddOrUpdateDigitalAssetRequest : IRequest<AddOrUpdateDigitalAssetResponse>
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class AddOrUpdateDigitalAssetResponse { }

        public class AddOrUpdateDigitalAssetHandler : IAsyncRequestHandler<AddOrUpdateDigitalAssetRequest, AddOrUpdateDigitalAssetResponse>
        {
            public AddOrUpdateDigitalAssetHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateDigitalAssetResponse> Handle(AddOrUpdateDigitalAssetRequest request)
            {
                var entity = await _dataContext.DigitalAssets
                    .SingleOrDefaultAsync(x => x.Id == request.DigitalAsset.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.DigitalAssets.Add(entity = new DigitalAsset());
                entity.Name = request.DigitalAsset.Name;
                entity.Folder = request.DigitalAsset.Folder;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateDigitalAssetResponse() { };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

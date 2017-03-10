using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetByUniqueIdQuery
    {
        public class GetDigitalAssetByUniqueIdRequest : IRequest<GetDigitalAssetByUniqueIdResponse>
        {
            public string UniqueId { get; set; }
        }

        public class GetDigitalAssetByUniqueIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; }
        }

        public class GetDigitalAssetByUniqueIdHandler : IAsyncRequestHandler<GetDigitalAssetByUniqueIdRequest, GetDigitalAssetByUniqueIdResponse>
        {
            public GetDigitalAssetByUniqueIdHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetDigitalAssetByUniqueIdResponse> Handle(GetDigitalAssetByUniqueIdRequest request)
            {
                return new GetDigitalAssetByUniqueIdResponse()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _dataContext.DigitalAssets.SingleAsync(x=>x.UniqueId.ToString() == request.UniqueId))
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

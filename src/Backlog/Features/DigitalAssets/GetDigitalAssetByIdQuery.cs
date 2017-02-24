using MediatR;
using Backlog.Data;
using System.Threading.Tasks;
using Backlog.Features.Core;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetByIdQuery
    {
        public class GetDigitalAssetByIdRequest : IRequest<GetDigitalAssetByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetDigitalAssetByIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; } 
		}

        public class GetDigitalAssetByIdHandler : IAsyncRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>
        {
            public GetDigitalAssetByIdHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetDigitalAssetByIdResponse> Handle(GetDigitalAssetByIdRequest request)
            {                
                return new GetDigitalAssetByIdResponse()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _dataContext.DigitalAssets.FindAsync(request.Id))
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

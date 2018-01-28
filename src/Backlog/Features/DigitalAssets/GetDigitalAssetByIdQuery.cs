using MediatR;
using Backlog.Data;
using System.Threading.Tasks;
using Backlog.Features.Core;

namespace Backlog.Features.DigitalAssets
{
    public class GetDigitalAssetByIdQuery
    {
        public class Request : IRequest<Response> { 
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
                return new Response()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _context.DigitalAssets.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

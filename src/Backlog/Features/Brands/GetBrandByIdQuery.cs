using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Brands
{
    public class GetBrandByIdQuery
    {
        public class GetBrandByIdRequest : IRequest<GetBrandByIdResponse> { 
            public int Id { get; set; }
        }

        public class GetBrandByIdResponse
        {
            public BrandApiModel Brand { get; set; } 
        }

        public class GetBrandByIdHandler : IAsyncRequestHandler<GetBrandByIdRequest, GetBrandByIdResponse>
        {
            public GetBrandByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetBrandByIdResponse> Handle(GetBrandByIdRequest request)
            {                
                return new GetBrandByIdResponse()
                {
                    Brand = BrandApiModel.FromBrand(await _context.Brands.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

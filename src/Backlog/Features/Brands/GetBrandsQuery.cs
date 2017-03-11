using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class GetBrandsQuery
    {
        public class GetBrandsRequest : IRequest<GetBrandsResponse> { }

        public class GetBrandsResponse
        {
            public ICollection<BrandApiModel> Brands { get; set; } = new HashSet<BrandApiModel>();
        }

        public class GetBrandsHandler : IAsyncRequestHandler<GetBrandsRequest, GetBrandsResponse>
        {
            public GetBrandsHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetBrandsResponse> Handle(GetBrandsRequest request)
            {
                var brands = await _dataContext.Brands.ToListAsync();
                return new GetBrandsResponse()
                {
                    Brands = brands.Select(x => BrandApiModel.FromBrand(x)).ToList()
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

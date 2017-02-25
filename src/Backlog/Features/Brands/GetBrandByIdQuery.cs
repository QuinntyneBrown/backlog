using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

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
            public GetBrandByIdHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetBrandByIdResponse> Handle(GetBrandByIdRequest request)
            {                
                return new GetBrandByIdResponse()
                {
                    Brand = BrandApiModel.FromBrand(await _dataContext.Brands.FindAsync(request.Id))
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

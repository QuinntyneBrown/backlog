using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Products
{
    public class GetProductByIdQuery
    {
        public class GetProductByIdRequest : IRequest<GetProductByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetProductByIdResponse
        {
            public ProductApiModel Product { get; set; } 
		}

        public class GetProductByIdHandler : IAsyncRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
        {
            public GetProductByIdHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request)
            {                
                return new GetProductByIdResponse()
                {
                    Product = ProductApiModel.FromProduct(await _dataContext.Products.FindAsync(request.Id))
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

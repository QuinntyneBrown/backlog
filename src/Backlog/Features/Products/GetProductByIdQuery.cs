using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

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
            public GetProductByIdHandler(IDataContext dataContext, ICache cache)
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

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
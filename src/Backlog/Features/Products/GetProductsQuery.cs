using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Products
{
    public class GetProductsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<ProductApiModel> Products { get; set; } = new HashSet<ProductApiModel>();
        }

        public class GetProductsHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetProductsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var products = await _context.Products.ToListAsync();
                return new Response()
                {
                    Products = products.Select(x => ProductApiModel.FromProduct(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

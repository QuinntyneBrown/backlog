using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

namespace Backlog.Features.Products
{
    public class GetProductByIdQuery
    {
        public class Request : IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public ProductApiModel Product { get; set; } 
		}

        public class GetProductByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetProductByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Product = ProductApiModel.FromProduct(await _context.Products.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
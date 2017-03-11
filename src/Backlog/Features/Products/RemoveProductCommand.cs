using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Products
{
    public class RemoveProductCommand
    {
        public class RemoveProductRequest : IRequest<RemoveProductResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveProductResponse { }

        public class RemoveProductHandler : IAsyncRequestHandler<RemoveProductRequest, RemoveProductResponse>
        {
            public RemoveProductHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveProductResponse> Handle(RemoveProductRequest request)
            {
                var product = await _context.Products.FindAsync(request.Id);
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveProductResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

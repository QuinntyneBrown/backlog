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
            public RemoveProductHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveProductResponse> Handle(RemoveProductRequest request)
            {
                var product = await _dataContext.Products.FindAsync(request.Id);
                product.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveProductResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

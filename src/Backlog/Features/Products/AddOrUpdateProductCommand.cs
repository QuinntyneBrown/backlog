using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Products
{
    public class AddOrUpdateProductCommand
    {
        public class AddOrUpdateProductRequest : IRequest<AddOrUpdateProductResponse>
        {
            public ProductApiModel Product { get; set; }
        }

        public class AddOrUpdateProductResponse
        {

        }

        public class AddOrUpdateProductHandler : IAsyncRequestHandler<AddOrUpdateProductRequest, AddOrUpdateProductResponse>
        {
            public AddOrUpdateProductHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateProductResponse> Handle(AddOrUpdateProductRequest request)
            {
                var entity = await _dataContext.Products
                    .SingleOrDefaultAsync(x => x.Id == request.Product.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Products.Add(entity = new Product());
                entity.Name = request.Product.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateProductResponse()
                {

                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

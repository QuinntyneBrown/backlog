using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backlog.Features.Products
{
    public class AddOrUpdateProductCommand
    {
        public class AddOrUpdateProductRequest : IRequest<AddOrUpdateProductResponse>
        {
            public ProductApiModel Product { get; set; }
        }

        public class AddOrUpdateProductResponse { }

        public class AddOrUpdateProductHandler : IAsyncRequestHandler<AddOrUpdateProductRequest, AddOrUpdateProductResponse>
        {
            public AddOrUpdateProductHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateProductResponse> Handle(AddOrUpdateProductRequest request)
            {
                var entity = await _context.Products
                    .SingleOrDefaultAsync(x => x.Id == request.Product.Id && x.IsDeleted == false);
                if (entity == null) _context.Products.Add(entity = new Product());
                entity.Name = request.Product.Name;
                entity.Slug = request.Product.Name.GenerateSlug();

                await _context.SaveChangesAsync();

                return new AddOrUpdateProductResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Http;

namespace Backlog.Features.Products
{
    public class AddOrUpdateProductCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public ProductApiModel Product { get; set; }
        }

        public class Response { }

        public class AddOrUpdateProductHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateProductHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                var entity = await _context.Products
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Product.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);

                    _context.Products.Add(entity = new Product() {
                        Tenant = tenant
                    });
                }

                entity.Name = request.Product.Name;
                entity.Slug = request.Product.Name.GenerateSlug();

                await _context.SaveChangesAsync(request.Username);

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
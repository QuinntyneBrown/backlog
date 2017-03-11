using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class AddOrUpdateBrandCommand
    {
        public class AddOrUpdateBrandRequest : IRequest<AddOrUpdateBrandResponse>
        {
            public BrandApiModel Brand { get; set; }
        }

        public class AddOrUpdateBrandResponse { }

        public class AddOrUpdateBrandHandler : IAsyncRequestHandler<AddOrUpdateBrandRequest, AddOrUpdateBrandResponse>
        {
            public AddOrUpdateBrandHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateBrandResponse> Handle(AddOrUpdateBrandRequest request)
            {
                var entity = await _context.Brands
                    .SingleOrDefaultAsync(x => x.Id == request.Brand.Id && x.IsDeleted == false);
                if (entity == null) _context.Brands.Add(entity = new Brand());
                entity.Name = request.Brand.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateBrandResponse() { };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
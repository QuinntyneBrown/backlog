using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class AddOrUpdateBrandCommand
    {
        public class AddOrUpdateBrandRequest : IRequest<AddOrUpdateBrandResponse>
        {
            public BrandApiModel Brand { get; set; }
        }

        public class AddOrUpdateBrandResponse
        {

        }

        public class AddOrUpdateBrandHandler : IAsyncRequestHandler<AddOrUpdateBrandRequest, AddOrUpdateBrandResponse>
        {
            public AddOrUpdateBrandHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateBrandResponse> Handle(AddOrUpdateBrandRequest request)
            {
                var entity = await _dataContext.Brands
                    .SingleOrDefaultAsync(x => x.Id == request.Brand.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Brands.Add(entity = new Brand());
                entity.Name = request.Brand.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateBrandResponse()
                {

                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

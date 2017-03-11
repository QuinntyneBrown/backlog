using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class RemoveBrandCommand
    {
        public class RemoveBrandRequest : IRequest<RemoveBrandResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveBrandResponse { }

        public class RemoveBrandHandler : IAsyncRequestHandler<RemoveBrandRequest, RemoveBrandResponse>
        {
            public RemoveBrandHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveBrandResponse> Handle(RemoveBrandRequest request)
            {
                var brand = await _dataContext.Brands.FindAsync(request.Id);
                brand.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveBrandResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

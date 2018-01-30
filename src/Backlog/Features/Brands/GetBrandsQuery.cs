using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class GetBrandsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<BrandApiModel> Brands { get; set; } = new HashSet<BrandApiModel>();
        }

        public class GetBrandsHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetBrandsHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var brands = await _context.Brands
                    .ToListAsync();

                return new Response()
                {
                    Brands = brands.Select(x => BrandApiModel.FromBrand(x)).ToList()
                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

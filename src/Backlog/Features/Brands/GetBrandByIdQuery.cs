using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Brands
{
    public class GetBrandByIdQuery
    {
        public class Request : IRequest<Response> { 
            public int Id { get; set; }
        }

        public class Response
        {
            public BrandApiModel Brand { get; set; } 
        }

        public class GetBrandByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetBrandByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Brand = BrandApiModel.FromBrand(await _context.Brands.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

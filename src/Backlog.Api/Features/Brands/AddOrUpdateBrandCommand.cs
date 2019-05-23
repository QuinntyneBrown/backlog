using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Brands
{
    public class AddOrUpdateBrandCommand
    {
        public class Request : IRequest<Response>
        {
            public BrandApiModel Brand { get; set; }
        }

        public class Response
        {

        }

        public class AddOrUpdateBrandHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateBrandHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Brands
                    .SingleOrDefaultAsync(x => x.Id == request.Brand.Id);
                if (entity == null) _context.Brands.Add(entity = new Brand());
                entity.Name = request.Brand.Name;
                await _context.SaveChangesAsync();

                return new Response()
                {

                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

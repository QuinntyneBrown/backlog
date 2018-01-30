using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Products
{
    public class RemoveProductCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveProductHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveProductHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var product = await _context.Products.FindAsync(request.Id);
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

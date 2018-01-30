using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

namespace Backlog.Features.Categories
{
    public class GetCategoryByIdQuery
    {
        public class Request : IRequest<Response> {
            public int Id { get; set; }
        }

        public class Response
        {
            public CategoryApiModel Category { get; set; } 
		}

        public class GetCategoryByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetCategoryByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                return new Response()
                {
                    Category = CategoryApiModel.FromCategory(await _context.Categories.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
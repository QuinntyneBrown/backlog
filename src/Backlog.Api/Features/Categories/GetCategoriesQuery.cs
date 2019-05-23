using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Categories
{
    public class GetCategoriesQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<CategoryApiModel> Categories { get; set; } = new HashSet<CategoryApiModel>();
        }

        public class GetCategoriesHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetCategoriesHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var categories = await _context.Categories
                    .Where(x=>x.IsDeleted == false)
                    .ToListAsync();

                return new Response()
                {
                    Categories = categories.Select(x => CategoryApiModel.FromCategory(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Categories
{
    public class AddOrUpdateCategoryCommand
    {
        public class Request : IRequest<Response>
        {
            public CategoryApiModel Category { get; set; }
        }

        public class Response { }

        public class AddOrUpdateCategoryHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateCategoryHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Categories
                    .SingleOrDefaultAsync(x => x.Id == request.Category.Id);
                if (entity == null) _context.Categories.Add(entity = new Category());
                entity.Name = request.Category.Name;
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

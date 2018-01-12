using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Categories
{
    public class RemoveCategoryCommand
    {
        public class RemoveCategoryRequest : IRequest<RemoveCategoryResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveCategoryResponse { }

        public class RemoveCategoryHandler : IAsyncRequestHandler<RemoveCategoryRequest, RemoveCategoryResponse>
        {
            public RemoveCategoryHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveCategoryResponse> Handle(RemoveCategoryRequest request)
            {
                var category = await _context.Categories.FindAsync(request.Id);
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveCategoryResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

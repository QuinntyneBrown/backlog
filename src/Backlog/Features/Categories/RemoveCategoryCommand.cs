using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
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
            public RemoveCategoryHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveCategoryResponse> Handle(RemoveCategoryRequest request)
            {
                var category = await _dataContext.Categories.FindAsync(request.Id);
                category.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveCategoryResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

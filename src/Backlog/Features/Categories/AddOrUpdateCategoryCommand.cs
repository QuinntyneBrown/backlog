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
    public class AddOrUpdateCategoryCommand
    {
        public class AddOrUpdateCategoryRequest : IRequest<AddOrUpdateCategoryResponse>
        {
            public CategoryApiModel Category { get; set; }
        }

        public class AddOrUpdateCategoryResponse
        {

        }

        public class AddOrUpdateCategoryHandler : IAsyncRequestHandler<AddOrUpdateCategoryRequest, AddOrUpdateCategoryResponse>
        {
            public AddOrUpdateCategoryHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateCategoryResponse> Handle(AddOrUpdateCategoryRequest request)
            {
                var entity = await _dataContext.Categories
                    .SingleOrDefaultAsync(x => x.Id == request.Category.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Categories.Add(entity = new Category());
                entity.Name = request.Category.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateCategoryResponse()
                {

                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

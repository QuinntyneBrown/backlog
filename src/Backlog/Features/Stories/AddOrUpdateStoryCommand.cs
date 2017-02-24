using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class AddOrUpdateStoryCommand
    {
        public class AddOrUpdateStoryRequest : IRequest<AddOrUpdateStoryResponse>
        {
            public StoryApiModel Story { get; set; }
        }

        public class AddOrUpdateStoryResponse
        {

        }

        public class AddOrUpdateStoryHandler : IAsyncRequestHandler<AddOrUpdateStoryRequest, AddOrUpdateStoryResponse>
        {
            public AddOrUpdateStoryHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateStoryResponse> Handle(AddOrUpdateStoryRequest request)
            {
                var entity = await _dataContext.Stories
                    .SingleOrDefaultAsync(x => x.Id == request.Story.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Stories.Add(entity = new Story());
                entity.Name = request.Story.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateStoryResponse()
                {

                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

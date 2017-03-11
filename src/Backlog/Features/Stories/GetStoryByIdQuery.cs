using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class GetStoryByIdQuery
    {
        public class GetStoryByIdRequest : IRequest<GetStoryByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetStoryByIdResponse
        {
            public StoryApiModel Story { get; set; } 
		}

        public class GetStoryByIdHandler : IAsyncRequestHandler<GetStoryByIdRequest, GetStoryByIdResponse>
        {
            public GetStoryByIdHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetStoryByIdResponse> Handle(GetStoryByIdRequest request)
            {                
                return new GetStoryByIdResponse()
                {
                    Story = StoryApiModel.FromStory(await _dataContext.Stories.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

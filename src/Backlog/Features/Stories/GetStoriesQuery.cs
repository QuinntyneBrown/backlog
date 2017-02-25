using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class GetStoriesQuery
    {
        public class GetStoriesRequest : IRequest<GetStoriesResponse> { }

        public class GetStoriesResponse
        {
            public ICollection<StoryApiModel> Stories { get; set; } = new HashSet<StoryApiModel>();
        }

        public class GetStoriesHandler : IAsyncRequestHandler<GetStoriesRequest, GetStoriesResponse>
        {
            public GetStoriesHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetStoriesResponse> Handle(GetStoriesRequest request)
            {
                var stories = await _dataContext.Stories.ToListAsync();
                return new GetStoriesResponse()
                {
                    Stories = stories.Select(x => StoryApiModel.FromStory(x)).ToList()
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

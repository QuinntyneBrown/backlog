using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class GetStorysQuery
    {
        public class GetStorysRequest : IRequest<GetStorysResponse> { }

        public class GetStorysResponse
        {
            public ICollection<StoryApiModel> Storys { get; set; } = new HashSet<StoryApiModel>();
        }

        public class GetStorysHandler : IAsyncRequestHandler<GetStorysRequest, GetStorysResponse>
        {
            public GetStorysHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetStorysResponse> Handle(GetStorysRequest request)
            {
                var storys = await _dataContext.Stories.ToListAsync();
                return new GetStorysResponse()
                {
                    Storys = storys.Select(x => StoryApiModel.FromStory(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

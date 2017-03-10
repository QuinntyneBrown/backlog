using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class GetTagsQuery
    {
        public class GetTagsRequest : IRequest<GetTagsResponse> { }

        public class GetTagsResponse
        {
            public ICollection<TagApiModel> Tags { get; set; } = new HashSet<TagApiModel>();
        }

        public class GetTagsHandler : IAsyncRequestHandler<GetTagsRequest, GetTagsResponse>
        {
            public GetTagsHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTagsResponse> Handle(GetTagsRequest request)
            {
                var tags = await _dataContext.Tags.ToListAsync();
                return new GetTagsResponse()
                {
                    Tags = tags.Select(x => TagApiModel.FromTag(x)).ToList()
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

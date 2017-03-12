using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
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
            public GetTagsHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetTagsResponse> Handle(GetTagsRequest request)
            {
                var tags = await _context.Tags
                    .Where(x=>x.IsDeleted == false)
                    .ToListAsync();

                return new GetTagsResponse()
                {
                    Tags = tags.Select(x => TagApiModel.FromTag(x)).ToList()
                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

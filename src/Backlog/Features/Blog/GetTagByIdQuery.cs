using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Blog
{
    public class GetTagByIdQuery
    {
        public class GetTagByIdRequest : IRequest<GetTagByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTagByIdResponse
        {
            public TagApiModel Tag { get; set; } 
		}

        public class GetTagByIdHandler : IAsyncRequestHandler<GetTagByIdRequest, GetTagByIdResponse>
        {
            public GetTagByIdHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTagByIdResponse> Handle(GetTagByIdRequest request)
            {                
                return new GetTagByIdResponse()
                {
                    Tag = TagApiModel.FromTag(await _dataContext.Tags.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
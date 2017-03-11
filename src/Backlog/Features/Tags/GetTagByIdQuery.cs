using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
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
            public GetTagByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetTagByIdResponse> Handle(GetTagByIdRequest request)
            {                
                return new GetTagByIdResponse()
                {
                    Tag = TagApiModel.FromTag(await _context.Tags.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

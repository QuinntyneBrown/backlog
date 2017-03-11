using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

namespace Backlog.Features.Sprints
{
    public class GetSprintByIdQuery
    {
        public class GetSprintByIdRequest : IRequest<GetSprintByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetSprintByIdResponse
        {
            public SprintApiModel Sprint { get; set; } 
		}

        public class GetSprintByIdHandler : IAsyncRequestHandler<GetSprintByIdRequest, GetSprintByIdResponse>
        {
            public GetSprintByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetSprintByIdResponse> Handle(GetSprintByIdRequest request)
            {                
                return new GetSprintByIdResponse()
                {
                    Sprint = SprintApiModel.FromSprint(await _context.Sprints.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
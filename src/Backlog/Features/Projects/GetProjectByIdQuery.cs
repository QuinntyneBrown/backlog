using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Projects
{
    public class GetProjectByIdQuery
    {
        public class GetProjectByIdRequest : IRequest<GetProjectByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetProjectByIdResponse
        {
            public ProjectApiModel Project { get; set; } 
		}

        public class GetProjectByIdHandler : IAsyncRequestHandler<GetProjectByIdRequest, GetProjectByIdResponse>
        {
            public GetProjectByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetProjectByIdResponse> Handle(GetProjectByIdRequest request)
            {                
                return new GetProjectByIdResponse()
                {
                    Project = ProjectApiModel.FromProject(await _context.Projects.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
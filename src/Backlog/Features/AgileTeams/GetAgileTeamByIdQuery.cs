using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamByIdQuery
    {
        public class GetAgileTeamByIdRequest : IRequest<GetAgileTeamByIdResponse> { 
            public int Id { get; set; }
        }

        public class GetAgileTeamByIdResponse
        {
            public AgileTeamApiModel AgileTeam { get; set; } 
		}

        public class GetAgileTeamByIdHandler : IAsyncRequestHandler<GetAgileTeamByIdRequest, GetAgileTeamByIdResponse>
        {
            public GetAgileTeamByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetAgileTeamByIdResponse> Handle(GetAgileTeamByIdRequest request)
            {                
                return new GetAgileTeamByIdResponse()
                {
                    AgileTeam = AgileTeamApiModel.FromAgileTeam(await _context.AgileTeams.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

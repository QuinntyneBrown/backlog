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
            public GetAgileTeamByIdHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAgileTeamByIdResponse> Handle(GetAgileTeamByIdRequest request)
            {                
                return new GetAgileTeamByIdResponse()
                {
                    AgileTeam = AgileTeamApiModel.FromAgileTeam(await _dataContext.AgileTeams.FindAsync(request.Id))
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

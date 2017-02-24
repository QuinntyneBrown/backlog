using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamsQuery
    {
        public class GetAgileTeamsRequest : IRequest<GetAgileTeamsResponse> { }

        public class GetAgileTeamsResponse
        {
            public ICollection<AgileTeamApiModel> AgileTeams { get; set; } = new HashSet<AgileTeamApiModel>();
        }

        public class GetAgileTeamsHandler : IAsyncRequestHandler<GetAgileTeamsRequest, GetAgileTeamsResponse>
        {
            public GetAgileTeamsHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAgileTeamsResponse> Handle(GetAgileTeamsRequest request)
            {
                var agileTeams = await _dataContext.AgileTeams.ToListAsync();
                return new GetAgileTeamsResponse()
                {
                    AgileTeams = agileTeams.Select(x => AgileTeamApiModel.FromAgileTeam(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamMembersQuery
    {
        public class GetAgileTeamMembersRequest : IRequest<GetAgileTeamMembersResponse> { }

        public class GetAgileTeamMembersResponse
        {
            public ICollection<AgileTeamMemberApiModel> AgileTeamMembers { get; set; } = new HashSet<AgileTeamMemberApiModel>();
        }

        public class GetAgileTeamMembersHandler : IAsyncRequestHandler<GetAgileTeamMembersRequest, GetAgileTeamMembersResponse>
        {
            public GetAgileTeamMembersHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAgileTeamMembersResponse> Handle(GetAgileTeamMembersRequest request)
            {
                var agileTeamMembers = await _dataContext.AgileTeamMembers.ToListAsync();
                return new GetAgileTeamMembersResponse()
                {
                    AgileTeamMembers = agileTeamMembers.Select(x => AgileTeamMemberApiModel.FromAgileTeamMember(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

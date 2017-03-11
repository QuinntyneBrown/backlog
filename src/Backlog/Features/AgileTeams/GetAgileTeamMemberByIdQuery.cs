using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamMemberByIdQuery
    {
        public class GetAgileTeamMemberByIdRequest : IRequest<GetAgileTeamMemberByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetAgileTeamMemberByIdResponse
        {
            public AgileTeamMemberApiModel AgileTeamMember { get; set; } 
		}

        public class GetAgileTeamMemberByIdHandler : IAsyncRequestHandler<GetAgileTeamMemberByIdRequest, GetAgileTeamMemberByIdResponse>
        {
            public GetAgileTeamMemberByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetAgileTeamMemberByIdResponse> Handle(GetAgileTeamMemberByIdRequest request)
            {                
                return new GetAgileTeamMemberByIdResponse()
                {
                    AgileTeamMember = AgileTeamMemberApiModel.FromAgileTeamMember(await _context.AgileTeamMembers.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

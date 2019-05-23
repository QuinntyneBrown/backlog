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
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<AgileTeamMemberApiModel> AgileTeamMembers { get; set; } = new HashSet<AgileTeamMemberApiModel>();
        }

        public class GetAgileTeamMembersHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetAgileTeamMembersHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var agileTeamMembers = await _context.AgileTeamMembers.ToListAsync();
                return new Response()
                {
                    AgileTeamMembers = agileTeamMembers.Select(x => AgileTeamMemberApiModel.FromAgileTeamMember(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

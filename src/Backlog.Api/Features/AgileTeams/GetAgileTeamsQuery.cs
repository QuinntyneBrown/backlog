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
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<AgileTeamApiModel> AgileTeams { get; set; } = new HashSet<AgileTeamApiModel>();
        }

        public class GetAgileTeamsHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetAgileTeamsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var agileTeams = await _context.AgileTeams.ToListAsync();
                return new Response()
                {
                    AgileTeams = agileTeams.Select(x => AgileTeamApiModel.FromAgileTeam(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

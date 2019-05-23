using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamByIdQuery
    {
        public class Request : IRequest<Response> { 
            public int Id { get; set; }
        }

        public class Response
        {
            public AgileTeamApiModel AgileTeam { get; set; } 
		}

        public class GetAgileTeamByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetAgileTeamByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    AgileTeam = AgileTeamApiModel.FromAgileTeam(await _context.AgileTeams.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

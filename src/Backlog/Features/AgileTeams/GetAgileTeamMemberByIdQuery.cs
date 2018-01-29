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
        public class Request : IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public AgileTeamMemberApiModel AgileTeamMember { get; set; } 
		}

        public class GetAgileTeamMemberByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetAgileTeamMemberByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    AgileTeamMember = AgileTeamMemberApiModel.FromAgileTeamMember(await _context.AgileTeamMembers.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

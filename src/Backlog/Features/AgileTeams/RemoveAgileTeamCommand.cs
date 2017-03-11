using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class RemoveAgileTeamCommand
    {
        public class RemoveAgileTeamRequest : IRequest<RemoveAgileTeamResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAgileTeamResponse { }

        public class RemoveAgileTeamHandler : IAsyncRequestHandler<RemoveAgileTeamRequest, RemoveAgileTeamResponse>
        {
            public RemoveAgileTeamHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveAgileTeamResponse> Handle(RemoveAgileTeamRequest request)
            {
                var agileTeam = await _context.AgileTeams.FindAsync(request.Id);
                agileTeam.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveAgileTeamResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

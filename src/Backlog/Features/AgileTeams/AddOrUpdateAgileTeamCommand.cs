using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class AddOrUpdateAgileTeamCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public AgileTeamApiModel AgileTeam { get; set; }
        }

        public class Response { }

        public class AddOrUpdateAgileTeamHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateAgileTeamHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.AgileTeams
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId)
                    .SingleOrDefaultAsync(x => x.Id == request.AgileTeam.Id);

                if (entity == null) _context.AgileTeams.Add(entity = new AgileTeam());

                entity.Name = request.AgileTeam.Name;

                await _context.SaveChangesAsync(request.Username);

                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

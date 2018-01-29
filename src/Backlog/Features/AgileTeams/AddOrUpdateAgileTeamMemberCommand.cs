using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class AddOrUpdateAgileTeamMemberCommand
    {
        public class Request : IRequest<Response>
        {
            public AgileTeamMemberApiModel AgileTeamMember { get; set; }
        }

        public class Response { }

        public class AddOrUpdateAgileTeamMemberHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateAgileTeamMemberHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.AgileTeamMembers
                    .SingleOrDefaultAsync(x => x.Id == request.AgileTeamMember.Id && x.IsDeleted == false);
                if (entity == null) _context.AgileTeamMembers.Add(entity = new AgileTeamMember());
                entity.Name = request.AgileTeamMember.Name;
                await _context.SaveChangesAsync();

                return new Response()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

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
    public class RemoveAgileTeamMemberCommand
    {
        public class RemoveAgileTeamMemberRequest : IRequest<RemoveAgileTeamMemberResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAgileTeamMemberResponse { }

        public class RemoveAgileTeamMemberHandler : IAsyncRequestHandler<RemoveAgileTeamMemberRequest, RemoveAgileTeamMemberResponse>
        {
            public RemoveAgileTeamMemberHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveAgileTeamMemberResponse> Handle(RemoveAgileTeamMemberRequest request)
            {
                var agileTeamMember = await _context.AgileTeamMembers.FindAsync(request.Id);
                agileTeamMember.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveAgileTeamMemberResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

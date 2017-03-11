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
            public RemoveAgileTeamMemberHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAgileTeamMemberResponse> Handle(RemoveAgileTeamMemberRequest request)
            {
                var agileTeamMember = await _dataContext.AgileTeamMembers.FindAsync(request.Id);
                agileTeamMember.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAgileTeamMemberResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

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
        public class AddOrUpdateAgileTeamMemberRequest : IRequest<AddOrUpdateAgileTeamMemberResponse>
        {
            public AgileTeamMemberApiModel AgileTeamMember { get; set; }
        }

        public class AddOrUpdateAgileTeamMemberResponse { }

        public class AddOrUpdateAgileTeamMemberHandler : IAsyncRequestHandler<AddOrUpdateAgileTeamMemberRequest, AddOrUpdateAgileTeamMemberResponse>
        {
            public AddOrUpdateAgileTeamMemberHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateAgileTeamMemberResponse> Handle(AddOrUpdateAgileTeamMemberRequest request)
            {
                var entity = await _context.AgileTeamMembers
                    .SingleOrDefaultAsync(x => x.Id == request.AgileTeamMember.Id && x.IsDeleted == false);
                if (entity == null) _context.AgileTeamMembers.Add(entity = new AgileTeamMember());
                entity.Name = request.AgileTeamMember.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateAgileTeamMemberResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

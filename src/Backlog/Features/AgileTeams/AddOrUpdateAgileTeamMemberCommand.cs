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
    public class AddOrUpdateAgileTeamMemberCommand
    {
        public class AddOrUpdateAgileTeamMemberRequest : IRequest<AddOrUpdateAgileTeamMemberResponse>
        {
            public AgileTeamMemberApiModel AgileTeamMember { get; set; }
        }

        public class AddOrUpdateAgileTeamMemberResponse { }

        public class AddOrUpdateAgileTeamMemberHandler : IAsyncRequestHandler<AddOrUpdateAgileTeamMemberRequest, AddOrUpdateAgileTeamMemberResponse>
        {
            public AddOrUpdateAgileTeamMemberHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAgileTeamMemberResponse> Handle(AddOrUpdateAgileTeamMemberRequest request)
            {
                var entity = await _dataContext.AgileTeamMembers
                    .SingleOrDefaultAsync(x => x.Id == request.AgileTeamMember.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.AgileTeamMembers.Add(entity = new AgileTeamMember());
                entity.Name = request.AgileTeamMember.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAgileTeamMemberResponse()
                {

                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

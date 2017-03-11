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
    public class AddOrUpdateAgileTeamCommand
    {
        public class AddOrUpdateAgileTeamRequest : IRequest<AddOrUpdateAgileTeamResponse>
        {
            public AgileTeamApiModel AgileTeam { get; set; }
        }

        public class AddOrUpdateAgileTeamResponse { }

        public class AddOrUpdateAgileTeamHandler : IAsyncRequestHandler<AddOrUpdateAgileTeamRequest, AddOrUpdateAgileTeamResponse>
        {
            public AddOrUpdateAgileTeamHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAgileTeamResponse> Handle(AddOrUpdateAgileTeamRequest request)
            {
                var entity = await _dataContext.AgileTeams
                    .SingleOrDefaultAsync(x => x.Id == request.AgileTeam.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.AgileTeams.Add(entity = new AgileTeam());
                entity.Name = request.AgileTeam.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAgileTeamResponse()
                {

                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

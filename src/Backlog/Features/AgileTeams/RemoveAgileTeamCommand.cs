using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
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
            public RemoveAgileTeamHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAgileTeamResponse> Handle(RemoveAgileTeamRequest request)
            {
                var agileTeam = await _dataContext.AgileTeams.FindAsync(request.Id);
                agileTeam.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAgileTeamResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

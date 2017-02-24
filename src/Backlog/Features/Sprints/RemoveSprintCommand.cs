using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Sprints
{
    public class RemoveSprintCommand
    {
        public class RemoveSprintRequest : IRequest<RemoveSprintResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveSprintResponse { }

        public class RemoveSprintHandler : IAsyncRequestHandler<RemoveSprintRequest, RemoveSprintResponse>
        {
            public RemoveSprintHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveSprintResponse> Handle(RemoveSprintRequest request)
            {
                var sprint = await _dataContext.Sprints.FindAsync(request.Id);
                sprint.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveSprintResponse();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

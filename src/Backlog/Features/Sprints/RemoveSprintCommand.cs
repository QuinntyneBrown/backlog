using MediatR;
using Backlog.Data;
using Backlog.Model;
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
            public RemoveSprintHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveSprintResponse> Handle(RemoveSprintRequest request)
            {
                var sprint = await _context.Sprints.FindAsync(request.Id);
                sprint.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveSprintResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

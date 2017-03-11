using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Projects
{
    public class RemoveProjectCommand
    {
        public class RemoveProjectRequest : IRequest<RemoveProjectResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveProjectResponse { }

        public class RemoveProjectHandler : IAsyncRequestHandler<RemoveProjectRequest, RemoveProjectResponse>
        {
            public RemoveProjectHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveProjectResponse> Handle(RemoveProjectRequest request)
            {
                var project = await _context.Projects.FindAsync(request.Id);
                project.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveProjectResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

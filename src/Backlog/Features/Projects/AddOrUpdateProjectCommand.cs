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
    public class AddOrUpdateProjectCommand
    {
        public class AddOrUpdateProjectRequest : IRequest<AddOrUpdateProjectResponse>
        {
            public ProjectApiModel Project { get; set; }
        }

        public class AddOrUpdateProjectResponse
        {

        }

        public class AddOrUpdateProjectHandler : IAsyncRequestHandler<AddOrUpdateProjectRequest, AddOrUpdateProjectResponse>
        {
            public AddOrUpdateProjectHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateProjectResponse> Handle(AddOrUpdateProjectRequest request)
            {
                var entity = await _context.Projects
                    .SingleOrDefaultAsync(x => x.Id == request.Project.Id && x.IsDeleted == false);
                if (entity == null) _context.Projects.Add(entity = new Project());
                entity.Name = request.Project.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateProjectResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

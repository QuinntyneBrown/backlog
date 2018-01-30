using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Projects
{
    public class AddOrUpdateProjectCommand
    {
        public class Request : IRequest<Response>
        {
            public ProjectApiModel Project { get; set; }
        }

        public class Response
        {

        }

        public class AddOrUpdateProjectHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateProjectHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Projects
                    .SingleOrDefaultAsync(x => x.Id == request.Project.Id && x.IsDeleted == false);
                if (entity == null) _context.Projects.Add(entity = new Project());
                entity.Name = request.Project.Name;
                await _context.SaveChangesAsync();

                return new Response()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

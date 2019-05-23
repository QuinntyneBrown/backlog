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
    public class AddOrUpdateSprintCommand
    {
        public class Request : IRequest<Response>
        {
            public SprintApiModel Sprint { get; set; }
        }

        public class Response
        {

        }

        public class AddOrUpdateSprintHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateSprintHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Sprints
                    .SingleOrDefaultAsync(x => x.Id == request.Sprint.Id && x.IsDeleted == false);
                if (entity == null) _context.Sprints.Add(entity = new Sprint());
                entity.Name = request.Sprint.Name;
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

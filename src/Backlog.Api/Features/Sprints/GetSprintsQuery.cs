using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Sprints
{
    public class GetSprintsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<SprintApiModel> Sprints { get; set; } = new HashSet<SprintApiModel>();
        }

        public class GetSprintsHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetSprintsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var sprints = await _context.Sprints.ToListAsync();
                return new Response()
                {
                    Sprints = sprints.Select(x => SprintApiModel.FromSprint(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

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
        public class GetSprintsRequest : IRequest<GetSprintsResponse> { }

        public class GetSprintsResponse
        {
            public ICollection<SprintApiModel> Sprints { get; set; } = new HashSet<SprintApiModel>();
        }

        public class GetSprintsHandler : IAsyncRequestHandler<GetSprintsRequest, GetSprintsResponse>
        {
            public GetSprintsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetSprintsResponse> Handle(GetSprintsRequest request)
            {
                var sprints = await _context.Sprints.ToListAsync();
                return new GetSprintsResponse()
                {
                    Sprints = sprints.Select(x => SprintApiModel.FromSprint(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

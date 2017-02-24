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
            public GetSprintsHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetSprintsResponse> Handle(GetSprintsRequest request)
            {
                var sprints = await _dataContext.Sprints.ToListAsync();
                return new GetSprintsResponse()
                {
                    Sprints = sprints.Select(x => SprintApiModel.FromSprint(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

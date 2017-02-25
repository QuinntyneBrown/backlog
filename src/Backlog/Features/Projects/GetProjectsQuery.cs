using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Projects
{
    public class GetProjectsQuery
    {
        public class GetProjectsRequest : IRequest<GetProjectsResponse> { }

        public class GetProjectsResponse
        {
            public ICollection<ProjectApiModel> Projects { get; set; } = new HashSet<ProjectApiModel>();
        }

        public class GetProjectsHandler : IAsyncRequestHandler<GetProjectsRequest, GetProjectsResponse>
        {
            public GetProjectsHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetProjectsResponse> Handle(GetProjectsRequest request)
            {
                var projects = await _dataContext.Projects.ToListAsync();
                return new GetProjectsResponse()
                {
                    Projects = projects.Select(x => ProjectApiModel.FromProject(x)).ToList()
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

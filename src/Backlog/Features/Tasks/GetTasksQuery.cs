using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tasks
{
    public class GetTasksQuery
    {
        public class GetTasksRequest : IRequest<GetTasksResponse> { }

        public class GetTasksResponse
        {
            public ICollection<TaskApiModel> Tasks { get; set; } = new HashSet<TaskApiModel>();
        }

        public class GetTasksHandler : IAsyncRequestHandler<GetTasksRequest, GetTasksResponse>
        {
            public GetTasksHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTasksResponse> Handle(GetTasksRequest request)
            {
                var tasks = await _dataContext.Tasks.ToListAsync();
                return new GetTasksResponse()
                {
                    Tasks = tasks.Select(x => TaskApiModel.FromTask(x)).ToList()
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

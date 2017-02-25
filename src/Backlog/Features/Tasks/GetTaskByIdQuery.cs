using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tasks
{
    public class GetTaskByIdQuery
    {
        public class GetTaskByIdRequest : IRequest<GetTaskByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTaskByIdResponse
        {
            public TaskApiModel Task { get; set; } 
		}

        public class GetTaskByIdHandler : IAsyncRequestHandler<GetTaskByIdRequest, GetTaskByIdResponse>
        {
            public GetTaskByIdHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTaskByIdResponse> Handle(GetTaskByIdRequest request)
            {                
                return new GetTaskByIdResponse()
                {
                    Task = TaskApiModel.FromTask(await _dataContext.Tasks.FindAsync(request.Id))
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

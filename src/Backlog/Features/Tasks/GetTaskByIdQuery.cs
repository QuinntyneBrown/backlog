using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

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
            public GetTaskByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetTaskByIdResponse> Handle(GetTaskByIdRequest request)
            {                
                return new GetTaskByIdResponse()
                {
                    Task = TaskApiModel.FromTask(await _context.Tasks.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
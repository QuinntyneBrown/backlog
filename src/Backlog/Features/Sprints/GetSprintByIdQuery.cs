using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

namespace Backlog.Features.Sprints
{
    public class GetSprintByIdQuery
    {
        public class GetSprintByIdRequest : IRequest<GetSprintByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetSprintByIdResponse
        {
            public SprintApiModel Sprint { get; set; } 
		}

        public class GetSprintByIdHandler : IAsyncRequestHandler<GetSprintByIdRequest, GetSprintByIdResponse>
        {
            public GetSprintByIdHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetSprintByIdResponse> Handle(GetSprintByIdRequest request)
            {                
                return new GetSprintByIdResponse()
                {
                    Sprint = SprintApiModel.FromSprint(await _dataContext.Sprints.FindAsync(request.Id))
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
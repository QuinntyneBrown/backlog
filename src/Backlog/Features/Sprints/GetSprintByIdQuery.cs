using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

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
            public GetSprintByIdHandler(DataContext dataContext, ICache cache)
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

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Projects
{
    public class GetProjectByIdQuery
    {
        public class GetProjectByIdRequest : IRequest<GetProjectByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetProjectByIdResponse
        {
            public ProjectApiModel Project { get; set; } 
		}

        public class GetProjectByIdHandler : IAsyncRequestHandler<GetProjectByIdRequest, GetProjectByIdResponse>
        {
            public GetProjectByIdHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetProjectByIdResponse> Handle(GetProjectByIdRequest request)
            {                
                return new GetProjectByIdResponse()
                {
                    Project = ProjectApiModel.FromProject(await _dataContext.Projects.FindAsync(request.Id))
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

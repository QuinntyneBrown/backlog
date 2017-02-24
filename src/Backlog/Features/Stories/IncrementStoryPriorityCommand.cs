using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class IncrementStoryPriorityCommand
    {
        public class IncrementStoryPriorityRequest : IRequest<IncrementStoryPriorityResponse>
        {
            public IncrementStoryPriorityRequest()
            {

            }
        }

        public class IncrementStoryPriorityResponse
        {
            public IncrementStoryPriorityResponse()
            {

            }
        }

        public class IncrementStoryPriorityHandler : IAsyncRequestHandler<IncrementStoryPriorityRequest, IncrementStoryPriorityResponse>
        {
            public IncrementStoryPriorityHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<IncrementStoryPriorityResponse> Handle(IncrementStoryPriorityRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

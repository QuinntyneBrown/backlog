using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Stories
{
    public class DecrementStoryPriorityCommand
    {
        public class DecrementStoryPriorityRequest : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response {}

        public class DecrementStoryPriorityHandler : IAsyncRequestHandler<DecrementStoryPriorityRequest, Response>
        {
            public DecrementStoryPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(DecrementStoryPriorityRequest request)
            {
				throw new System.NotImplementedException();
            }

            protected readonly IBacklogContext _context;
            protected readonly ICache _cache;
        }
    }
}

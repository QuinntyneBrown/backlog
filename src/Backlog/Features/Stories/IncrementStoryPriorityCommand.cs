using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.Stories
{
    public class IncrementStoryPriorityCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response> { }

        public class Response { }

        public class IncrementStoryPriorityHandler : IAsyncRequestHandler<Request, Response>
        {
            public IncrementStoryPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
				throw new System.NotImplementedException();
            }

            protected readonly IBacklogContext _context;
            protected readonly ICache _cache;
        }
    }
}

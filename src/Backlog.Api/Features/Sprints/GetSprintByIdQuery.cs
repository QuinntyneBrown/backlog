using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;

namespace Backlog.Features.Sprints
{
    public class GetSprintByIdQuery
    {
        public class Request : IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public SprintApiModel Sprint { get; set; } 
		}

        public class GetSprintByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetSprintByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Sprint = SprintApiModel.FromSprint(await _context.Sprints.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
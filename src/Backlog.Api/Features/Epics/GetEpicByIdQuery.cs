using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class GetEpicByIdQuery
    {
        public class Request : IRequest<Response> { 
            public int Id { get; set; }
        }

        public class Response
        {
            public EpicApiModel Epic { get; set; } 
        }

        public class GetEpicByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetEpicByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Epic = EpicApiModel.FromEpic(await _context.Epics
                    .Include(x => x.Stories)
                    .Include(x => x.Product)
                    .SingleAsync(x => x.Id == request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
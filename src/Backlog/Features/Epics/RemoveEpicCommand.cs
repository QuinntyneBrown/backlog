using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class RemoveEpicCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveEpicHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveEpicHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var epic = await _context.Epics.FindAsync(request.Id);
                epic.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

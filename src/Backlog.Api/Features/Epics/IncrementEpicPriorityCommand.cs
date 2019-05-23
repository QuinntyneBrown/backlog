using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;

namespace Backlog.Features.Epics
{
    public class IncrementEpicPriorityCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class IncrementEpicPriorityHandler : IAsyncRequestHandler<Request, Response>
        {
            public IncrementEpicPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var epicTask = _context.Epics.FindAsync(request.Id);
                var epicsTasks = _context.Epics.Where(x => x.IsDeleted == false).ToListAsync();
                WaitAll(new Task[] { epicTask, epicsTasks });
                epicTask.Result.IncrementPriority(new List<IPrioritizable>(epicsTasks.Result.Cast<IPrioritizable>()));
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
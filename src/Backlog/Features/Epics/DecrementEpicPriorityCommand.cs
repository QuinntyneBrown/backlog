using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Data.Model;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;

namespace Backlog.Features.Epics
{
    public class DecrementEpicPriorityCommand
    {
        public class DecrementEpicPriorityRequest : IRequest<DecrementEpicPriorityResponse>
        {
            public int Id { get; set; }
        }

        public class DecrementEpicPriorityResponse { }

        public class DecrementEpicPriorityHandler : IAsyncRequestHandler<DecrementEpicPriorityRequest, DecrementEpicPriorityResponse>
        {
            public DecrementEpicPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<DecrementEpicPriorityResponse> Handle(DecrementEpicPriorityRequest request)
            {
                var epicTask = _context.Epics.FindAsync(request.Id);
                var epicsTasks =_context.Epics.Where(x => x.IsDeleted == false).ToListAsync();                
                WaitAll(new Task[] { epicTask, epicsTasks });
                epicTask.Result.DecrementPriority(new List<IPrioritizable>(epicsTasks.Result.Cast<IPrioritizable>()));
                await _context.SaveChangesAsync();
                return new DecrementEpicPriorityResponse();
            }
            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
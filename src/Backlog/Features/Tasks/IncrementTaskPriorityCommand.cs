using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;
using Backlog.Data.Model;

namespace Backlog.Features.Tasks
{
    public class IncrementTaskPriorityCommand
    {
        public class IncrementTaskPriorityRequest : IRequest<IncrementTaskPriorityResponse>
        {
            public int Id { get; set; }
        }

        public class IncrementTaskPriorityResponse { }

        public class IncrementTaskPriorityHandler : IAsyncRequestHandler<IncrementTaskPriorityRequest, IncrementTaskPriorityResponse>
        {
            public IncrementTaskPriorityHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<IncrementTaskPriorityResponse> Handle(IncrementTaskPriorityRequest request)
            {
                var taskTask = _dataContext.Tasks.FindAsync(request.Id);
                var taskTasks = _dataContext.Tasks.Where(x => x.IsDeleted == false).ToListAsync();
                WaitAll(new Task[] { taskTask, taskTasks });
                taskTask.Result.IncrementPriority(new List<IPrioritizable>(taskTasks.Result.Cast<IPrioritizable>()));
                await _dataContext.SaveChangesAsync();
                return new IncrementTaskPriorityResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

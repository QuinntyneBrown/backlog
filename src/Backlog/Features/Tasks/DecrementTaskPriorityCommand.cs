using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;
using Backlog.Data.Models;

namespace Backlog.Features.Tasks
{
    public class DecrementTaskPriorityCommand
    {
        public class DecrementTaskPriorityRequest : IRequest<DecrementTaskPriorityResponse> {
            public int Id { get; set; }
        }

        public class DecrementTaskPriorityResponse { }

        public class DecrementTaskPriorityHandler : IAsyncRequestHandler<DecrementTaskPriorityRequest, DecrementTaskPriorityResponse>
        {
            public DecrementTaskPriorityHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<DecrementTaskPriorityResponse> Handle(DecrementTaskPriorityRequest request)
            {
                var taskTask = _dataContext.Tasks.FindAsync(request.Id);
                var taskTasks = _dataContext.Tasks.Where(x => x.IsDeleted == false).ToListAsync();
                WaitAll(new Task[] { taskTask, taskTasks });
                taskTask.Result.DecrementPriority(new List<IPrioritizable>(taskTasks.Result.Cast<IPrioritizable>()));
                await _dataContext.SaveChangesAsync();
                return new DecrementTaskPriorityResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
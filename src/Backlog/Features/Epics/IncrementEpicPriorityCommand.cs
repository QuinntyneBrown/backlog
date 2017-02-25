using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Data.Models;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;

namespace Backlog.Features.Epics
{
    public class IncrementEpicPriorityCommand
    {
        public class IncrementEpicPriorityRequest : IRequest<IncrementEpicPriorityResponse>
        {
            public int Id { get; set; }
        }

        public class IncrementEpicPriorityResponse { }

        public class IncrementEpicPriorityHandler : IAsyncRequestHandler<IncrementEpicPriorityRequest, IncrementEpicPriorityResponse>
        {
            public IncrementEpicPriorityHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<IncrementEpicPriorityResponse> Handle(IncrementEpicPriorityRequest request)
            {
                var epicTask = _dataContext.Epics.FindAsync(request.Id);
                var epicsTasks = _dataContext.Epics.Where(x => x.IsDeleted == false).ToListAsync();
                WaitAll(new Task[] { epicTask, epicsTasks });
                epicTask.Result.IncrementPriority(new List<IPrioritizable>(epicsTasks.Result.Cast<IPrioritizable>()));
                await _dataContext.SaveChangesAsync();
                return new IncrementEpicPriorityResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
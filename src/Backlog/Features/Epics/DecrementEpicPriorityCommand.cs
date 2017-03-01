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
    public class DecrementEpicPriorityCommand
    {
        public class DecrementEpicPriorityRequest : IRequest<DecrementEpicPriorityResponse>
        {
            public int Id { get; set; }
        }

        public class DecrementEpicPriorityResponse { }

        public class DecrementEpicPriorityHandler : IAsyncRequestHandler<DecrementEpicPriorityRequest, DecrementEpicPriorityResponse>
        {
            public DecrementEpicPriorityHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<DecrementEpicPriorityResponse> Handle(DecrementEpicPriorityRequest request)
            {
                var epicTask = _dataContext.Epics.FindAsync(request.Id);
                var epicsTasks =_dataContext.Epics.Where(x => x.IsDeleted == false).ToListAsync();                
                WaitAll(new Task[] { epicTask, epicsTasks });
                epicTask.Result.DecrementPriority(new List<IPrioritizable>(epicsTasks.Result.Cast<IPrioritizable>()));
                await _dataContext.SaveChangesAsync();
                return new DecrementEpicPriorityResponse();
            }
            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
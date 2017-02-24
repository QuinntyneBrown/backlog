using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Task = System.Threading.Tasks.Task;
using static System.Threading.Tasks.Task;


namespace Backlog.Features.Tasks
{
    public class RemoveTaskCommand
    {
        public class RemoveTaskRequest : IRequest<RemoveTaskResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTaskResponse { }

        public class RemoveTaskHandler : IAsyncRequestHandler<RemoveTaskRequest, RemoveTaskResponse>
        {
            public RemoveTaskHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveTaskResponse> Handle(RemoveTaskRequest request)
            {
                var task = await _dataContext.Tasks.FindAsync(request.Id);
                task.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveTaskResponse();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

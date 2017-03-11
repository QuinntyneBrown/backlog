using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
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
            public RemoveTaskHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveTaskResponse> Handle(RemoveTaskRequest request)
            {
                var task = await _context.Tasks.FindAsync(request.Id);
                task.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveTaskResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

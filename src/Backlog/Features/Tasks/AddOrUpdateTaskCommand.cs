using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Task = Backlog.Data.Model.Task;

namespace Backlog.Features.Tasks
{
    public class AddOrUpdateTaskCommand
    {
        public class AddOrUpdateTaskRequest : IRequest<AddOrUpdateTaskResponse>
        {
            public TaskApiModel Task { get; set; }
        }

        public class AddOrUpdateTaskResponse
        {

        }

        public class AddOrUpdateTaskHandler : IAsyncRequestHandler<AddOrUpdateTaskRequest, AddOrUpdateTaskResponse>
        {
            public AddOrUpdateTaskHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateTaskResponse> Handle(AddOrUpdateTaskRequest request)
            {
                var entity = await _context.Tasks
                    .SingleOrDefaultAsync(x => x.Id == request.Task.Id && x.IsDeleted == false);
                if (entity == null) _context.Tasks.Add(entity = new Task());
                entity.Name = request.Task.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateTaskResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

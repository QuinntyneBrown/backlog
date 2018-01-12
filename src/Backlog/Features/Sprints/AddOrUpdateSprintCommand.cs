using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Sprints
{
    public class AddOrUpdateSprintCommand
    {
        public class AddOrUpdateSprintRequest : IRequest<AddOrUpdateSprintResponse>
        {
            public SprintApiModel Sprint { get; set; }
        }

        public class AddOrUpdateSprintResponse
        {

        }

        public class AddOrUpdateSprintHandler : IAsyncRequestHandler<AddOrUpdateSprintRequest, AddOrUpdateSprintResponse>
        {
            public AddOrUpdateSprintHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateSprintResponse> Handle(AddOrUpdateSprintRequest request)
            {
                var entity = await _context.Sprints
                    .SingleOrDefaultAsync(x => x.Id == request.Sprint.Id && x.IsDeleted == false);
                if (entity == null) _context.Sprints.Add(entity = new Sprint());
                entity.Name = request.Sprint.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateSprintResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

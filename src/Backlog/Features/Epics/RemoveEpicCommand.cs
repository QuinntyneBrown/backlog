using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class RemoveEpicCommand
    {
        public class RemoveEpicRequest : IRequest<RemoveEpicResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveEpicResponse { }

        public class RemoveEpicHandler : IAsyncRequestHandler<RemoveEpicRequest, RemoveEpicResponse>
        {
            public RemoveEpicHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveEpicResponse> Handle(RemoveEpicRequest request)
            {
                var epic = await _dataContext.Epics.FindAsync(request.Id);
                epic.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveEpicResponse();
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Data.Models;

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
            public DecrementEpicPriorityHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<DecrementEpicPriorityResponse> Handle(DecrementEpicPriorityRequest request)
            {
                var epic = await _dataContext.Epics.FindAsync(request.Id);
                var epics = new List<IPrioritizable>((await _dataContext.Epics.Where(x => x.IsDeleted == false).ToListAsync()).Cast<IPrioritizable>());
                epic.DecrementPriority(epics);
                await _dataContext.SaveChangesAsync();
                return new DecrementEpicPriorityResponse();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

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
    public class IncrementEpicPriorityCommand
    {
        public class IncrementEpicPriorityRequest : IRequest<IncrementEpicPriorityResponse>
        {
            public int Id { get; set; }
        }

        public class IncrementEpicPriorityResponse { }

        public class IncrementEpicPriorityHandler : IAsyncRequestHandler<IncrementEpicPriorityRequest, IncrementEpicPriorityResponse>
        {
            public IncrementEpicPriorityHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<IncrementEpicPriorityResponse> Handle(IncrementEpicPriorityRequest request)
            {
                var epic = await _dataContext.Epics.FindAsync(request.Id);
                var epics = new List<IPrioritizable>((await _dataContext.Epics.Where(x => x.IsDeleted == false).ToListAsync()).Cast<IPrioritizable>());                
                epic.IncrementPriority(epics);
                await _dataContext.SaveChangesAsync();
                return new IncrementEpicPriorityResponse();                
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

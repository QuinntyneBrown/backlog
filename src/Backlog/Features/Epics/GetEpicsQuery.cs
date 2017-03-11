using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class GetEpicsQuery
    {
        public class GetEpicsRequest : IRequest<GetEpicsResponse> {
            public int? TenantId { get; set; }
        }

        public class GetEpicsResponse
        {
            public ICollection<EpicApiModel> Epics { get; set; } = new HashSet<EpicApiModel>();
        }

        public class GetEpicsHandler : IAsyncRequestHandler<GetEpicsRequest, GetEpicsResponse>
        {
            public GetEpicsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetEpicsResponse> Handle(GetEpicsRequest request)
            {
                var epics = await _context.Epics
                    .Include(x=>x.Stories)
                    .Include(x=>x.Product)
                    .Where(x=>x.TenantId == request.TenantId)
                    .ToListAsync();

                return new GetEpicsResponse()
                {
                    Epics = epics.Select(x => EpicApiModel.FromEpic(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class GetEpicsQuery
    {
        public class GetEpicsRequest : IRequest<GetEpicsResponse> { }

        public class GetEpicsResponse
        {
            public ICollection<EpicApiModel> Epics { get; set; } = new HashSet<EpicApiModel>();
        }

        public class GetEpicsHandler : IAsyncRequestHandler<GetEpicsRequest, GetEpicsResponse>
        {
            public GetEpicsHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetEpicsResponse> Handle(GetEpicsRequest request)
            {
                var epics = await _dataContext.Epics.ToListAsync();
                return new GetEpicsResponse()
                {
                    Epics = epics.Select(x => EpicApiModel.FromEpic(x)).ToList()
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

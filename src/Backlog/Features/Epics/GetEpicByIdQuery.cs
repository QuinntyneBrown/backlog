using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Epics
{
    public class GetEpicByIdQuery
    {
        public class GetEpicByIdRequest : IRequest<GetEpicByIdResponse> { 
            public int Id { get; set; }
        }

        public class GetEpicByIdResponse
        {
            public EpicApiModel Epic { get; set; } 
        }

        public class GetEpicByIdHandler : IAsyncRequestHandler<GetEpicByIdRequest, GetEpicByIdResponse>
        {
            public GetEpicByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetEpicByIdResponse> Handle(GetEpicByIdRequest request)
            {                
                return new GetEpicByIdResponse()
                {
                    Epic = EpicApiModel.FromEpic(await _context.Epics
                    .Include(x => x.Stories)
                    .Include(x => x.Product)
                    .SingleAsync(x => x.Id == request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System;
using System.Threading.Tasks;

namespace Backlog.Features.Tenants
{
    public class VerifyTenantCommand
    {
        public class Request : IRequest<Response>
        {
            public Guid UniqueId { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                if (request.UniqueId != new Guid("bad9a182-ede0-418d-9588-2d89cfd555bd"))
                    throw new Exception("Invalid Request");
                
                return await Task.FromResult(new Response());
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
{
    public class GetTagByIdQuery
    {
        public class Request : IRequest<Response> { 
            public int Id { get; set; }
        }

        public class Response
        {
            public TagApiModel Tag { get; set; } 
        }

        public class GetTagByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetTagByIdHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Tag = TagApiModel.FromTag(await _context.Tags.FindAsync(request.Id))
                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Users
{
    public class GetUserByIdQuery
    {
        public class Request : IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public UserApiModel User { get; set; } 
		}

        public class GetUserByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetUserByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    User = UserApiModel.FromUser(await _context.Users
                    .Include(x => x.Profile)
                    .SingleAsync(x => x.Id == request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

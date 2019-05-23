using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
{
    public class AddOrUpdateTagCommand
    {
        public class Request : IRequest<Response>
        {
            public TagApiModel Tag { get; set; }
        }

        public class Response
        {

        }

        public class AddOrUpdateTagHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateTagHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Tags
                    .SingleOrDefaultAsync(x => x.Id == request.Tag.Id && x.IsDeleted == false);
                if (entity == null) _context.Tags.Add(entity = new Tag());
                entity.Name = request.Tag.Name;
                await _context.SaveChangesAsync();

                return new Response()
                {

                };
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Model;

namespace Backlog.Features.Blog
{
    public class AddOrUpdateAuthorCommand
    {
        public class Request : IRequest<Response>
        {
            public AuthorApiModel Author { get; set; }
        }

        public class Response { }

        public class AddOrUpdateAuthorHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateAuthorHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Authors
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.IsDeleted == false);
                if (entity == null) _context.Authors.Add(entity = new Author());

                entity.Firstname = request.Author.Firstname;
                entity.Lastname = request.Author.Lastname;
                entity.AvatarUrl = request.Author.AvatarUrl;

                await _context.SaveChangesAsync();

                return new Response() { };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
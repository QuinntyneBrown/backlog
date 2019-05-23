using Backlog.Data;
using Backlog.Features.Core;
using Backlog.Model;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Blog
{
    public class AddOrUpdateAuthorCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
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
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.Tenant.UniqueId == request.TenantUniqueId);

                if (entity == null) _context.Authors.Add(entity = new Author());

                entity.Firstname = request.Author.Firstname;
                entity.Lastname = request.Author.Lastname;
                entity.AvatarUrl = request.Author.AvatarUrl;

                await _context.SaveChangesAsync(request.Username);

                return new Response() { };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
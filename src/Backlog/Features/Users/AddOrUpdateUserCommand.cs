using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Users
{
    public class AddOrUpdateUserCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public UserApiModel User { get; set; }
        }

        public class Response { }

        public class AddOrUpdateUserHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateUserHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context
                    .Users
                    .Include(x =>x.Tenant)
                    .Include(x => x.Roles)
                    .Include(x => x.Profile)
                    .SingleOrDefaultAsync(x => x.Id == request.User.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null)
                {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Users.Add(entity = new User()
                    {
                        TenantId = tenant.Id
                    });
                }
                
                entity.Profile.AvatarImageUrl = request.User.Profile.AvatarImageUrl;
                entity.Profile.Name = request.User.Profile.Name;

                await _context.SaveChangesAsync();

                return new Response() { };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
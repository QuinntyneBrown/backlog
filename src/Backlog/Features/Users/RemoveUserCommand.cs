using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Users
{
    public class RemoveUserCommand
    {
        public class RemoveUserRequest : IRequest<RemoveUserResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveUserResponse { }

        public class RemoveUserHandler : IAsyncRequestHandler<RemoveUserRequest, RemoveUserResponse>
        {
            public RemoveUserHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveUserResponse> Handle(RemoveUserRequest request)
            {
                var user = await _context.Users.FindAsync(request.Id);
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveUserResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}

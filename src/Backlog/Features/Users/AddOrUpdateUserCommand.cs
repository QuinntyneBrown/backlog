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
    public class AddOrUpdateUserCommand
    {
        public class AddOrUpdateUserRequest : IRequest<AddOrUpdateUserResponse>
        {
            public UserApiModel User { get; set; }
        }

        public class AddOrUpdateUserResponse
        {

        }

        public class AddOrUpdateUserHandler : IAsyncRequestHandler<AddOrUpdateUserRequest, AddOrUpdateUserResponse>
        {
            public AddOrUpdateUserHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateUserResponse> Handle(AddOrUpdateUserRequest request)
            {
                var entity = await _context.Users
                    .SingleOrDefaultAsync(x => x.Id == request.User.Id && x.IsDeleted == false);
                if (entity == null) _context.Users.Add(entity = new User());
                entity.Name = request.User.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateUserResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}

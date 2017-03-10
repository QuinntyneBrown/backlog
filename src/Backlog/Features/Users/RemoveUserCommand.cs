using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
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
            public RemoveUserHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveUserResponse> Handle(RemoveUserRequest request)
            {
                var user = await _dataContext.Users.FindAsync(request.Id);
                user.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveUserResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

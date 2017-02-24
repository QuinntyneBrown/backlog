using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Users
{
    public class GetUserByUsernameQuery
    {
        public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
        {
            public string Username { get; set; }
        }

        public class GetUserByUsernameResponse
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserByUsernameHandler : IAsyncRequestHandler<GetUserByUsernameRequest, GetUserByUsernameResponse>
        {
            public GetUserByUsernameHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetUserByUsernameResponse> Handle(GetUserByUsernameRequest request)
            {
                return new GetUserByUsernameResponse()
                {
                    User = UserApiModel.FromUser(await _dataContext.Users.SingleAsync(x=>x.Username == request.Username))
                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
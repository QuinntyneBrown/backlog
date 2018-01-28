using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;

namespace Backlog.Features.Security
{
    public class IsAuthenticatedQuery
    {
        public class Request : IRequest<Response>
        {
            public string OAuthToken { get; set; }
        }

        public class Response
        {
            public bool Result { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IBacklogContext context, ICache cache, Lazy<IAuthConfiguration> lazyAuthConfiguration)
            {
                _context = context;
                _cache = cache;
                _authConfiguration = lazyAuthConfiguration.Value;
            }

            public async Task<Response> Handle(Request request)
            {
                var validationParameters =
                        new TokenValidationParameters
                        {
                            ValidIssuer = _authConfiguration.JwtIssuer,
                            ValidAudiences = new[] { _authConfiguration.JwtAudience },
                            IssuerSigningKeys = new[] { new InMemorySymmetricSecurityKey(Convert.FromBase64String(_authConfiguration.JwtKey)) },
                        };

                SecurityToken validatedToken;
                var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(request.OAuthToken, validationParameters, out validatedToken);

                if (!claimsPrincipal.Identity.IsAuthenticated)
                    throw new Exception();

                return await Task.FromResult(new Response()
                {
                    Result = true
                });
            }
            
            private readonly IBacklogContext _context;
            private readonly ICache _cache;
            private readonly IAuthConfiguration _authConfiguration;
        }
    }
}

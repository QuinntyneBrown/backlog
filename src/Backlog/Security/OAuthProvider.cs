using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using MediatR;

namespace Backlog.Security
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public OAuthProvider(Lazy<IAuthConfiguration> lazyAuthConfiguration, IMediator mediator)
        {
            _lazyAuthConfiguration = lazyAuthConfiguration;
            _mediator = mediator;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(_authConfiguration.AuthType);
            var username = context.OwinContext.Get<string>($"{_authConfiguration.AuthType}:username");
            var response = await _mediator.Send(new GetClaimsForUserQuery.GetClaimsForUserRequest() { Username = username });

            foreach (var claim in response.Claims)
            {
                identity.AddClaim(claim);
            }
            context.Validated(identity);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];
                var response = await _mediator.Send(new AuthenticateCommand.AuthenticateRequest() { Username = username, Password = password });
                if (response.IsAuthenticated)
                {
                    context.OwinContext.Set($"{_authConfiguration.AuthType}:username", username);
                    context.Validated();
                }
                else
                {
                    context.SetError("Invalid credentials");
                    context.Rejected();
                }
            }
            catch (Exception exception)
            {
                context.SetError(exception.Message);
                context.Rejected();
            }            
        }

        protected IMediator _mediator { get; set; }
        protected IAuthConfiguration _authConfiguration { get { return _lazyAuthConfiguration.Value; } }
        protected Lazy<IAuthConfiguration> _lazyAuthConfiguration;
    }
}

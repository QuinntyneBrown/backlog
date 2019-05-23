using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backlog.Features.Core
{
    public class BaseApiController : ApiController
    {
        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            if (request.GetType().IsSubclassOf(typeof(BaseRequest)))
                (request as BaseRequest).TenantUniqueId = new Guid(Request.GetHeaderValue("Tenant"));

            if (request.GetType().IsSubclassOf(typeof(BaseAuthenticatedRequest)))
                (request as BaseAuthenticatedRequest).Username = User.Identity.Name;

            return _mediator.Send(request);
        }

        private IMediator _mediator;
    }
}

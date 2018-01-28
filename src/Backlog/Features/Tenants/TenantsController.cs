using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Tenants
{    
    [RoutePrefix("api/tenants")]
    public class TenantController : BaseApiController
    {
        public TenantController(IMediator mediator)
            :base(mediator){ }

        [AllowAnonymous]
        [Route("verify")]
        [ResponseType(typeof(VerifyTenantCommand.Response))]
        public async Task<IHttpActionResult> Verify(VerifyTenantCommand.Request request)
            => Ok(await Send(request));
    }
}

using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.AgileTeams
{
    [Authorize]
    [RoutePrefix("api/agileteammembers")]
    public class AgileTeamMemberController : BaseApiController
    {        
        public AgileTeamMemberController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAgileTeamMemberCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAgileTeamMemberCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAgileTeamMemberCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAgileTeamMemberCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamMembersQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetAgileTeamMembersQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamMemberByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAgileTeamMemberByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAgileTeamMemberCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAgileTeamMemberCommand.Request request)
            => Ok(await Send(request));
        
    }
}

using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.AgileTeams
{
    [Authorize]
    [RoutePrefix("api/agileTeam")]
    public class AgileTeamController : BaseApiController
    {
        public AgileTeamController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAgileTeamCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAgileTeamCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAgileTeamCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAgileTeamCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetAgileTeamsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAgileTeamByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAgileTeamCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAgileTeamCommand.Request request)
            => Ok(await Send(request));
    }
}

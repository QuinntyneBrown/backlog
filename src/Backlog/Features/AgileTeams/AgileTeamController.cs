using Backlog.Features.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.AgileTeams
{
    [Authorize]
    [RoutePrefix("api/agileTeam")]
    public class AgileTeamController : ApiController
    {
        public AgileTeamController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAgileTeamCommand.AddOrUpdateAgileTeamResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAgileTeamCommand.AddOrUpdateAgileTeamRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAgileTeamCommand.AddOrUpdateAgileTeamResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAgileTeamCommand.AddOrUpdateAgileTeamRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamsQuery.GetAgileTeamsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetAgileTeamsQuery.GetAgileTeamsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamByIdQuery.GetAgileTeamByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAgileTeamByIdQuery.GetAgileTeamByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAgileTeamCommand.RemoveAgileTeamResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAgileTeamCommand.RemoveAgileTeamRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

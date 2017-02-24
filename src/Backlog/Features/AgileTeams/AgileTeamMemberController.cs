using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.AgileTeams
{
    [Authorize]
    [RoutePrefix("api/agileTeamMember")]
    public class AgileTeamMemberController : ApiController
    {
        public AgileTeamMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAgileTeamMemberCommand.AddOrUpdateAgileTeamMemberResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAgileTeamMemberCommand.AddOrUpdateAgileTeamMemberRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAgileTeamMemberCommand.AddOrUpdateAgileTeamMemberResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAgileTeamMemberCommand.AddOrUpdateAgileTeamMemberRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamMembersQuery.GetAgileTeamMembersResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetAgileTeamMembersQuery.GetAgileTeamMembersRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAgileTeamMemberByIdQuery.GetAgileTeamMemberByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAgileTeamMemberByIdQuery.GetAgileTeamMemberByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAgileTeamMemberCommand.RemoveAgileTeamMemberResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAgileTeamMemberCommand.RemoveAgileTeamMemberRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

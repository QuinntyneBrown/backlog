using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Sprints
{
    [Authorize]
    [RoutePrefix("api/sprint")]
    public class SprintController : ApiController
    {
        public SprintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateSprintCommand.AddOrUpdateSprintResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateSprintCommand.AddOrUpdateSprintRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateSprintCommand.AddOrUpdateSprintResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateSprintCommand.AddOrUpdateSprintRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetSprintsQuery.GetSprintsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetSprintsQuery.GetSprintsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetSprintByIdQuery.GetSprintByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetSprintByIdQuery.GetSprintByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveSprintCommand.RemoveSprintResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveSprintCommand.RemoveSprintRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

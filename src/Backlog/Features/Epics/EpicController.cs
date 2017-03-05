using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Epics
{
    [Authorize]
    [RoutePrefix("api/epic")]
    public class EpicController : ApiController
    {        
        public EpicController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateEpicCommand.AddOrUpdateEpicResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateEpicCommand.AddOrUpdateEpicRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateEpicCommand.AddOrUpdateEpicResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateEpicCommand.AddOrUpdateEpicRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetEpicsQuery.GetEpicsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetEpicsQuery.GetEpicsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetEpicByIdQuery.GetEpicByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetEpicByIdQuery.GetEpicByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveEpicCommand.RemoveEpicResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveEpicCommand.RemoveEpicRequest request)
            => Ok(await _mediator.Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementEpicPriorityCommand.IncrementEpicPriorityResponse))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementEpicPriorityCommand.IncrementEpicPriorityRequest request)
            => Ok(await _mediator.Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementEpicPriorityCommand.DecrementEpicPriorityResponse))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]IncrementEpicPriorityCommand.IncrementEpicPriorityRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

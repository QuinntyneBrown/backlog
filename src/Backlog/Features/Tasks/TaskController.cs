using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Tasks
{
    [Authorize]
    [RoutePrefix("api/task")]
    public class TaskController : ApiController
    {
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTaskCommand.AddOrUpdateTaskResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTaskCommand.AddOrUpdateTaskRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTaskCommand.AddOrUpdateTaskResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTaskCommand.AddOrUpdateTaskRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTasksQuery.GetTasksResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTasksQuery.GetTasksRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTaskByIdQuery.GetTaskByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTaskByIdQuery.GetTaskByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTaskCommand.RemoveTaskResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTaskCommand.RemoveTaskRequest request)
            => Ok(await _mediator.Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementTaskPriorityCommand.IncrementTaskPriorityResponse))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementTaskPriorityCommand.IncrementTaskPriorityRequest request)
            => Ok(await _mediator.Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementTaskPriorityCommand.DecrementTaskPriorityResponse))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]IncrementTaskPriorityCommand.IncrementTaskPriorityRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

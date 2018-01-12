using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Tasks
{
    [Authorize]
    [RoutePrefix("api/tasks")]
    public class TaskController : BaseApiController
    {
        public TaskController(IMediator mediator)
            : base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTaskCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTaskCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTaskCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTaskCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GetTasksQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetTasksQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTaskByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTaskByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTaskCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTaskCommand.Request request)
            => Ok(await Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementTaskPriorityCommand.Response))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementTaskPriorityCommand.Request request)
            => Ok(await Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementTaskPriorityCommand.Response))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]DecrementTaskPriorityCommand.Request request)
            => Ok(await Send(request));

        protected readonly IMediator _mediator;
    }
}

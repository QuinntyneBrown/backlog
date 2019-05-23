using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Stories
{
    [Authorize]
    [RoutePrefix("api/stories")]
    public class StoryController : BaseApiController
    {
        public StoryController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateStoryCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateStoryCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateStoryCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateStoryCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GetStoriesQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetStoriesQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetStoryByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetStoryByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveStoryCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveStoryCommand.Request request)
            => Ok(await Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementStoryPriorityCommand.Response))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementStoryPriorityCommand.Request request)
            => Ok(await Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementStoryPriorityCommand.Response))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]IncrementStoryPriorityCommand.Request request)
            => Ok(await Send(request));

        protected readonly IMediator _mediator;
    }
}

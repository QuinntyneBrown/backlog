using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Stories
{
    [Authorize]
    [RoutePrefix("api/story")]
    public class StoryController : ApiController
    {
        public StoryController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateStoryCommand.AddOrUpdateStoryResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateStoryCommand.AddOrUpdateStoryRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateStoryCommand.AddOrUpdateStoryResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateStoryCommand.AddOrUpdateStoryRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetStoriesQuery.GetStoriesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetStoriesQuery.GetStoriesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetStoryByIdQuery.GetStoryByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetStoryByIdQuery.GetStoryByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveStoryCommand.RemoveStoryResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveStoryCommand.RemoveStoryRequest request)
            => Ok(await _mediator.Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementStoryPriorityCommand.IncrementStoryPriorityResponse))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementStoryPriorityCommand.IncrementStoryPriorityRequest request)
            => Ok(await _mediator.Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementStoryPriorityCommand.DecrementStoryPriorityResponse))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]IncrementStoryPriorityCommand.IncrementStoryPriorityRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

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
        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
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
        [ResponseType(typeof(GetStorysQuery.GetStorysResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetStorysQuery.GetStorysRequest()));

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

        protected readonly IMediator _mediator;

    }
}

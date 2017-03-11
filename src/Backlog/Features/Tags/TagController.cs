using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Tags
{
    [Authorize]
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        public TagController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTagCommand.AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTagCommand.AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTagCommand.AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTagCommand.AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTagsQuery.GetTagsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTagsQuery.GetTagsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTagByIdQuery.GetTagByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTagByIdQuery.GetTagByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTagCommand.RemoveTagResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTagCommand.RemoveTagRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

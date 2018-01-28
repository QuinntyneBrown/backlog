using Backlog.Features.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static Backlog.Features.Tags.AddOrUpdateTagCommand;
using static Backlog.Features.Tags.GetTagsQuery;
using static Backlog.Features.Tags.GetTagByIdQuery;
using static Backlog.Features.Tags.RemoveTagCommand;

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
        [ResponseType(typeof(AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTagResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTagRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTagsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTagsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTagByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTagByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTagResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTagRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

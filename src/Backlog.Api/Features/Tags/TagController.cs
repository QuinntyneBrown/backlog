using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Tags
{
    [Authorize]
    [RoutePrefix("api/tags")]
    public class TagController : BaseApiController
    {
        public TagController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTagCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTagCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTagCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTagCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTagsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetTagsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTagByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTagByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTagCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTagCommand.Request request)
            => Ok(await Send(request));        
    }
}

using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Blog
{
    [Authorize]
    [RoutePrefix("api/authors")]
    public class AuthorController : BaseApiController
    {
        public AuthorController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAuthorCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAuthorCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAuthorCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAuthorCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAuthorsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetAuthorsQuery.GetAuthorsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAuthorByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAuthorByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAuthorCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAuthorCommand.Request request)
            => Ok(await Send(request));
    }
}

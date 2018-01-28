using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Users
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateUserCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateUserCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateUserCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateUserCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetUsersQuery.GetUsersResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetUsersQuery.GetUsersRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetUserByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetUserByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveUserCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveUserCommand.Request request)
            => Ok(await Send(request));
        
        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        [ResponseType(typeof(SignUpUserCommand.Response))]
        public async Task<IHttpActionResult> Current(SignUpUserCommand.Request request)
            => Ok(await Send(request));

        [Route("current")]
        [HttpGet]
        [AllowAnonymous]
        [ResponseType(typeof(GetUserByUsernameQuery.Response))]
        public async Task<IHttpActionResult> Current() 
        {
            if (!User.Identity.IsAuthenticated)
                return Ok();
            
            return Ok(await Send(new GetUserByUsernameQuery.Request()));
        }

        protected readonly IMediator _mediator;        
    }
}

using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Projects
{
    [Authorize]
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        public ProjectController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateProjectCommand.AddOrUpdateProjectResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateProjectCommand.AddOrUpdateProjectRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateProjectCommand.AddOrUpdateProjectResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateProjectCommand.AddOrUpdateProjectRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetProjectsQuery.GetProjectsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetProjectsQuery.GetProjectsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetProjectByIdQuery.GetProjectByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetProjectByIdQuery.GetProjectByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveProjectCommand.RemoveProjectResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveProjectCommand.RemoveProjectRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

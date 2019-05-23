using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Projects
{
    [Authorize]
    [RoutePrefix("api/projects")]
    public class ProjectController : BaseApiController
    {
        public ProjectController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateProjectCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateProjectCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateProjectCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateProjectCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetProjectsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetProjectsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetProjectByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetProjectByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveProjectCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveProjectCommand.Request request)
            => Ok(await Send(request));
    }
}

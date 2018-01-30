using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Sprints
{
    [Authorize]
    [RoutePrefix("api/sprints")]
    public class SprintController : BaseApiController
    {
        public SprintController(IMediator mediator)
            :base(mediator)
        { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateSprintCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateSprintCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateSprintCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateSprintCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetSprintsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetSprintsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetSprintByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetSprintByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveSprintCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveSprintCommand.Request request)
            => Ok(await Send(request));
    }
}

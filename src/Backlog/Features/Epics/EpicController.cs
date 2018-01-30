using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Epics
{
    [Authorize]
    [RoutePrefix("api/epics")]
    public class EpicController : BaseApiController
    {        
        public EpicController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateEpicCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateEpicCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateEpicCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateEpicCommand.Request request)
            => Ok(await Send(request));

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GetEpicsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetEpicsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetEpicByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetEpicByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveEpicCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveEpicCommand.Request request)
            => Ok(await Send(request));

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(IncrementEpicPriorityCommand.Response))]
        public async Task<IHttpActionResult> IncrementPriority([FromUri]IncrementEpicPriorityCommand.Request request)
            => Ok(await Send(request));

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(DecrementEpicPriorityCommand.Response))]
        public async Task<IHttpActionResult> DecrementPriority([FromUri]DecrementEpicPriorityCommand.Request request)
            => Ok(await Send(request));
    }
}
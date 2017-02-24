using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Epics
{
    [Authorize]
    [RoutePrefix("api/epic")]
    public class EpicController : ApiController
    {
        public EpicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateEpicCommand.AddOrUpdateEpicResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateEpicCommand.AddOrUpdateEpicRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateEpicCommand.AddOrUpdateEpicResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateEpicCommand.AddOrUpdateEpicRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetEpicsQuery.GetEpicsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetEpicsQuery.GetEpicsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetEpicByIdQuery.GetEpicByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetEpicByIdQuery.GetEpicByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveEpicCommand.RemoveEpicResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveEpicCommand.RemoveEpicRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

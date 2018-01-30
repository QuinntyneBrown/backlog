using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Feedback
{
    [Authorize]
    [RoutePrefix("api/feedbacks")]
    public class FeedbackController : BaseApiController
    {
        public FeedbackController(IMediator mediator)
            :base(mediator){ }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateFeedbackCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateFeedbackCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateFeedbackCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateFeedbackCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetFeedbacksQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetFeedbacksQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetFeedbackByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetFeedbackByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveFeedbackCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveFeedbackCommand.Request request)
            => Ok(await Send(request));
    }
}

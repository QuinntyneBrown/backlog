using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Feedback
{
    [Authorize]
    [RoutePrefix("api/feedback")]
    public class FeedbackController : ApiController
    {
        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateFeedbackCommand.AddOrUpdateFeedbackResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateFeedbackCommand.AddOrUpdateFeedbackRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateFeedbackCommand.AddOrUpdateFeedbackResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateFeedbackCommand.AddOrUpdateFeedbackRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetFeedbacksQuery.GetFeedbacksResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetFeedbacksQuery.GetFeedbacksRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetFeedbackByIdQuery.GetFeedbackByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetFeedbackByIdQuery.GetFeedbackByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveFeedbackCommand.RemoveFeedbackResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveFeedbackCommand.RemoveFeedbackRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/feedback")]
    public class FeedbackController : ApiController
    {
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(FeedbackAddOrUpdateResponseDto))]
        public IHttpActionResult Add(FeedbackAddOrUpdateRequestDto dto) { return Ok(_feedbackService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(FeedbackAddOrUpdateResponseDto))]
        public IHttpActionResult Update(FeedbackAddOrUpdateRequestDto dto) { return Ok(_feedbackService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<FeedbackDto>))]
        public IHttpActionResult Get() { return Ok(_feedbackService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(FeedbackDto))]
        public IHttpActionResult GetById(int id) { return Ok(_feedbackService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_feedbackService.Remove(id)); }

        protected readonly IFeedbackService _feedbackService;


    }
}

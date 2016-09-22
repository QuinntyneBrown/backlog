using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/story")]
    public class StoryController : ApiController
    {
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(StoryAddOrUpdateResponseDto))]
        public IHttpActionResult Add(StoryAddOrUpdateRequestDto dto) { return Ok(_storyService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(StoryAddOrUpdateResponseDto))]
        public IHttpActionResult Update(StoryAddOrUpdateRequestDto dto) { return Ok(_storyService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<StoryDto>))]
        public IHttpActionResult Get() { return Ok(_storyService.Get()); }

        [Route("getReusableStories")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<StoryDto>))]
        public IHttpActionResult GetReusableStories() { return Ok(_storyService.GetReusableStories()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(StoryDto))]
        public IHttpActionResult GetById(int id) { return Ok(_storyService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_storyService.Remove(id)); }

        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        public IHttpActionResult IncrementPriority(int id) { return Ok(_storyService.IncrementPriority(id)); }

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        public IHttpActionResult DecrementPriority(int id) { return Ok(_storyService.DecrementPriority(id)); }

        protected readonly IStoryService _storyService;


    }
}

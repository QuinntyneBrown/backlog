using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(TagAddOrUpdateResponseDto))]
        public IHttpActionResult Add(TagAddOrUpdateRequestDto dto) { return Ok(_tagService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(TagAddOrUpdateResponseDto))]
        public IHttpActionResult Update(TagAddOrUpdateRequestDto dto) { return Ok(_tagService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<TagDto>))]
        public IHttpActionResult Get() { return Ok(_tagService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(TagDto))]
        public IHttpActionResult GetById(int id) { return Ok(_tagService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_tagService.Remove(id)); }

        protected readonly ITagService _tagService;


    }
}

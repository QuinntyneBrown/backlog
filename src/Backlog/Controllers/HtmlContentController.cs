using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/htmlContent")]
    public class HtmlContentController : ApiController
    {
        public HtmlContentController(IHtmlContentService htmlContentService)
        {
            _htmlContentService = htmlContentService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(HtmlContentAddOrUpdateResponseDto))]
        public IHttpActionResult Add(HtmlContentAddOrUpdateRequestDto dto) { return Ok(_htmlContentService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(HtmlContentAddOrUpdateResponseDto))]
        public IHttpActionResult Update(HtmlContentAddOrUpdateRequestDto dto) { return Ok(_htmlContentService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<HtmlContentDto>))]
        public IHttpActionResult Get() { return Ok(_htmlContentService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(HtmlContentDto))]
        public IHttpActionResult GetById(int id) { return Ok(_htmlContentService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_htmlContentService.Remove(id)); }

        protected readonly IHtmlContentService _htmlContentService;


    }
}

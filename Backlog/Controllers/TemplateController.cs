using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/template")]
    public class TemplateController : ApiController
    {
        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(TemplateAddOrUpdateResponseDto))]
        public IHttpActionResult Add(TemplateAddOrUpdateRequestDto dto) { return Ok(_templateService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(TemplateAddOrUpdateResponseDto))]
        public IHttpActionResult Update(TemplateAddOrUpdateRequestDto dto) { return Ok(_templateService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<TemplateDto>))]
        public IHttpActionResult Get() { return Ok(_templateService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(TemplateDto))]
        public IHttpActionResult GetById(int id) { return Ok(_templateService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_templateService.Remove(id)); }

        protected readonly ITemplateService _templateService;


    }
}

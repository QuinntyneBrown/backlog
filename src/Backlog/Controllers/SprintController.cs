using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/sprint")]
    public class SprintController : ApiController
    {
        public SprintController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(SprintAddOrUpdateResponseDto))]
        public IHttpActionResult Add(SprintAddOrUpdateRequestDto dto) { return Ok(_sprintService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(SprintAddOrUpdateResponseDto))]
        public IHttpActionResult Update(SprintAddOrUpdateRequestDto dto) { return Ok(_sprintService.AddOrUpdate(dto)); }

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(ICollection<SprintDto>))]
        public IHttpActionResult Get() { return Ok(_sprintService.Get()); }

        [Route("getCurrent")]
        [HttpGet]
        [ResponseType(typeof(SprintDto))]
        public IHttpActionResult GetCurrent() { return Ok(_sprintService.Get()); }
        
        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(SprintDto))]
        public IHttpActionResult GetById(int id) { return Ok(_sprintService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_sprintService.Remove(id)); }

        protected readonly ISprintService _sprintService;


    }
}

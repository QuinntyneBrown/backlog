using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/epic")]
    public class EpicController : ApiController
    {
        public EpicController(IEpicService epicService)
        {
            _epicService = epicService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(EpicAddOrUpdateResponseDto))]
        public IHttpActionResult Add(EpicAddOrUpdateRequestDto dto)
        { return Ok(_epicService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(EpicAddOrUpdateResponseDto))]
        public IHttpActionResult Update(EpicAddOrUpdateRequestDto dto) { return Ok(_epicService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        public IHttpActionResult Get() { return Ok(_epicService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(EpicDto))]
        public IHttpActionResult GetById(int id) { return Ok(_epicService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_epicService.Remove(id)); }

        protected readonly IEpicService _epicService;


    }
}

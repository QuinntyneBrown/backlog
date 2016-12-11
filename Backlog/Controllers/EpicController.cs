using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;
using static Backlog.Infrastructure.Constants;

namespace Backlog.Controllers
{

    [RoutePrefix("api/epic")]
    [Authorize]
    public class EpicController : ApiController
    {
        public EpicController(IEpicService epicService)
        {
            _epicService = epicService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(EpicAddOrUpdateResponseDto))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Add(EpicAddOrUpdateRequestDto dto)
        { return Ok(_epicService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(EpicAddOrUpdateResponseDto))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Update(EpicAddOrUpdateRequestDto dto) { return Ok(_epicService.AddOrUpdate(dto)); }

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        [CacheOutput(ServerTimeSpan = CacheOutputServerTimeSpan)]
        public IHttpActionResult Get() { return Ok(_epicService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(EpicDto))]
        public IHttpActionResult GetById(int id) { return Ok(_epicService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Remove(int id) { return Ok(_epicService.Remove(id)); }


        [Route("incrementPriority")]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult IncrementPriority(int id) { return Ok(_epicService.IncrementPriority(id)); }

        [Route("decrementPriority")]
        [HttpGet]
        [ResponseType(typeof(ICollection<EpicDto>))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult DecrementPriority(int id) { return Ok(_epicService.DecrementPriority(id)); }


        protected readonly IEpicService _epicService;


    }
}

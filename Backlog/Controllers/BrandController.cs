using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(BrandAddOrUpdateResponseDto))]
        public IHttpActionResult Add(BrandAddOrUpdateRequestDto dto) { return Ok(_brandService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(BrandAddOrUpdateResponseDto))]
        public IHttpActionResult Update(BrandAddOrUpdateRequestDto dto) { return Ok(_brandService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<BrandDto>))]
        public IHttpActionResult Get() { return Ok(_brandService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(BrandDto))]
        public IHttpActionResult GetById(int id) { return Ok(_brandService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_brandService.Remove(id)); }

        protected readonly IBrandService _brandService;


    }
}

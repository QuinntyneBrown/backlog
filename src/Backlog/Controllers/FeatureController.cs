using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/feature")]
    public class FeatureController : ApiController
    {
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(FeatureAddOrUpdateResponseDto))]
        public IHttpActionResult Add(FeatureAddOrUpdateRequestDto dto) { return Ok(_featureService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(FeatureAddOrUpdateResponseDto))]
        public IHttpActionResult Update(FeatureAddOrUpdateRequestDto dto) { return Ok(_featureService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<FeatureDto>))]
        public IHttpActionResult Get() { return Ok(_featureService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(FeatureDto))]
        public IHttpActionResult GetById(int id) { return Ok(_featureService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_featureService.Remove(id)); }

        protected readonly IFeatureService _featureService;


    }
}

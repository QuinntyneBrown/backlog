using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/reusableStoryGroup")]
    public class ReusableStoryGroupController : ApiController
    {
        public ReusableStoryGroupController(IReusableStoryGroupService reusableStoryGroupService)
        {
            _reusableStoryGroupService = reusableStoryGroupService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ReusableStoryGroupAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ReusableStoryGroupAddOrUpdateRequestDto dto) { return Ok(_reusableStoryGroupService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ReusableStoryGroupAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ReusableStoryGroupAddOrUpdateRequestDto dto) { return Ok(_reusableStoryGroupService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ReusableStoryGroupDto>))]
        public IHttpActionResult Get() { return Ok(_reusableStoryGroupService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ReusableStoryGroupDto))]
        public IHttpActionResult GetById(int id) { return Ok(_reusableStoryGroupService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_reusableStoryGroupService.Remove(id)); }

        protected readonly IReusableStoryGroupService _reusableStoryGroupService;


    }
}

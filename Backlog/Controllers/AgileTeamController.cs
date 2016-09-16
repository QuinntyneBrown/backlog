using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/agileTeam")]
    public class AgileTeamController : ApiController
    {
        public AgileTeamController(IAgileTeamService agileTeamService)
        {
            _agileTeamService = agileTeamService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AgileTeamAddOrUpdateResponseDto))]
        public IHttpActionResult Add(AgileTeamAddOrUpdateRequestDto dto) { return Ok(_agileTeamService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AgileTeamAddOrUpdateResponseDto))]
        public IHttpActionResult Update(AgileTeamAddOrUpdateRequestDto dto) { return Ok(_agileTeamService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<AgileTeamDto>))]
        public IHttpActionResult Get() { return Ok(_agileTeamService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(AgileTeamDto))]
        public IHttpActionResult GetById(int id) { return Ok(_agileTeamService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_agileTeamService.Remove(id)); }

        protected readonly IAgileTeamService _agileTeamService;


    }
}

using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/agileTeamMember")]
    public class AgileTeamMemberController : ApiController
    {
        public AgileTeamMemberController(IAgileTeamMemberService agileTeamMemberService)
        {
            _agileTeamMemberService = agileTeamMemberService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AgileTeamMemberAddOrUpdateResponseDto))]
        public IHttpActionResult Add(AgileTeamMemberAddOrUpdateRequestDto dto) { return Ok(_agileTeamMemberService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AgileTeamMemberAddOrUpdateResponseDto))]
        public IHttpActionResult Update(AgileTeamMemberAddOrUpdateRequestDto dto) { return Ok(_agileTeamMemberService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<AgileTeamMemberDto>))]
        public IHttpActionResult Get() { return Ok(_agileTeamMemberService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(AgileTeamMemberDto))]
        public IHttpActionResult GetById(int id) { return Ok(_agileTeamMemberService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_agileTeamMemberService.Remove(id)); }

        protected readonly IAgileTeamMemberService _agileTeamMemberService;


    }
}

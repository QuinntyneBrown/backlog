using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/userSettings")]
    public class UserSettingsController : ApiController
    {
        public UserSettingsController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(UserSettingsAddOrUpdateResponseDto))]
        public IHttpActionResult Add(UserSettingsAddOrUpdateRequestDto dto) { return Ok(_userSettingsService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(UserSettingsAddOrUpdateResponseDto))]
        public IHttpActionResult Update(UserSettingsAddOrUpdateRequestDto dto) { return Ok(_userSettingsService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<UserSettingsDto>))]
        public IHttpActionResult Get() { return Ok(_userSettingsService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(UserSettingsDto))]
        public IHttpActionResult GetById(int id) { return Ok(_userSettingsService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_userSettingsService.Remove(id)); }

        protected readonly IUserSettingsService _userSettingsService;


    }
}

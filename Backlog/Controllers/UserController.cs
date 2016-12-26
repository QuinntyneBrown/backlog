using Backlog.ApiModels;
using Backlog.Requests;
using Backlog.Responses;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("current")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(UserApiModel))]
        public IHttpActionResult Current()
        {            
            if (!User.Identity.IsAuthenticated)
                return Ok();
            return Ok(_userService.Current(User.Identity.Name));
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(UserAddOrUpdateResponse))]
        public IHttpActionResult Add(UserAddOrUpdateRequest dto) { return Ok(_userService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(UserAddOrUpdateResponse))]
        public IHttpActionResult Update(UserAddOrUpdateRequest dto) { return Ok(_userService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<UserApiModel>))]
        public IHttpActionResult Get() { return Ok(_userService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(UserApiModel))]
        public IHttpActionResult GetById(int id) { return Ok(_userService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_userService.Remove(id)); }

        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(RegistrationRequestDto request)
        {
            return Ok(_userService.Register(request, new List<string>() { }));
        }

        protected readonly IUserService _userService;


    }
}

using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/author")]
    public class AuthorController : ApiController
    {
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AuthorAddOrUpdateResponseDto))]
        public IHttpActionResult Add(AuthorAddOrUpdateRequestDto dto) { return Ok(_authorService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AuthorAddOrUpdateResponseDto))]
        public IHttpActionResult Update(AuthorAddOrUpdateRequestDto dto) { return Ok(_authorService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<AuthorDto>))]
        public IHttpActionResult Get() { return Ok(_authorService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(AuthorDto))]
        public IHttpActionResult GetById(int id) { return Ok(_authorService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_authorService.Remove(id)); }

        protected readonly IAuthorService _authorService;


    }
}

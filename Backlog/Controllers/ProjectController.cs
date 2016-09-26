using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ProjectAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ProjectAddOrUpdateRequestDto dto) { return Ok(_projectService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ProjectAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ProjectAddOrUpdateRequestDto dto) { return Ok(_projectService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ProjectDto>))]
        public IHttpActionResult Get() { return Ok(_projectService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ProjectDto))]
        public IHttpActionResult GetById(int id) { return Ok(_projectService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_projectService.Remove(id)); }

        protected readonly IProjectService _projectService;


    }
}

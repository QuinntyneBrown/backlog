using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/task")]
    public class TaskController : ApiController
    {
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(TaskAddOrUpdateResponseDto))]
        public IHttpActionResult Add(TaskAddOrUpdateRequestDto dto) { return Ok(_taskService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(TaskAddOrUpdateResponseDto))]
        public IHttpActionResult Update(TaskAddOrUpdateRequestDto dto) { return Ok(_taskService.AddOrUpdate(dto)); }

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(ICollection<TaskDto>))]
        public IHttpActionResult Get() { return Ok(_taskService.Get()); }

        [Route("gettaskstatuses")]
        [HttpGet]
        [ResponseType(typeof(ICollection<TaskStatusDto>))]
        public IHttpActionResult GetTaskStatuses() { return Ok(_taskService.GetTaskStatuses()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(TaskDto))]
        public IHttpActionResult GetById(int id) { return Ok(_taskService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_taskService.Remove(id)); }

        [Route("getByStoryId")]
        [HttpGet]
        [ResponseType(typeof(ICollection<TaskDto>))]
        public IHttpActionResult GetByStoryId(int? storyId) {
            return Ok(_taskService.GetByStoryId(storyId.Value));
        }
        
        protected readonly ITaskService _taskService;        
    }
}

using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/kanbanBoard")]
    public class KanbanBoardController : ApiController
    {
        public KanbanBoardController(IKanbanBoardService kanbanBoardService)
        {
            _kanbanBoardService = kanbanBoardService;
        }

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(ICollection<KanbanBoardDto>))]
        public IHttpActionResult Get()
        {
            return Ok();
        }
        
        protected readonly IKanbanBoardService _kanbanBoardService;

    }
}

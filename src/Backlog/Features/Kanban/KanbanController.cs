using MediatR;
using System.Web.Http;

namespace Backlog.Features.Kanban
{
    [Authorize]
    [RoutePrefix("api/kanban")]
    public class KanbanController : ApiController
    {
        public KanbanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        protected readonly IMediator _mediator;
    }
}
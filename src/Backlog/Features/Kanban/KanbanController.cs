using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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

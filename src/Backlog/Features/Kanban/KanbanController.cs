using Backlog.Features.Core;
using MediatR;
using System.Web.Http;

namespace Backlog.Features.Kanban
{
    [RoutePrefix("api/kanbans")]
    public class KanbanController : BaseApiController
    {
        public KanbanController(IMediator mediator)
            :base(mediator){ }
        
    }
}
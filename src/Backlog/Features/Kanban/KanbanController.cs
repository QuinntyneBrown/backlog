using Backlog.Security;
using MediatR;
using System.Web.Http;

namespace Backlog.Features.Kanban
{
    [Authorize]
    [RoutePrefix("api/kanban")]
    public class KanbanController : ApiController
    {
        public KanbanController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        
        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}
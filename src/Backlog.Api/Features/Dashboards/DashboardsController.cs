using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Backlog.Features.Core;

namespace Backlog.Features.Dashboards
{
    [Authorize]
    [RoutePrefix("api/dashboards")]
    public class DashboardController : BaseApiController
    {
        public DashboardController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateDashboardCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateDashboardCommand.Request request) => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateDashboardCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateDashboardCommand.Request request) => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetDashboardsQuery.Response))]
        public async Task<IHttpActionResult> Get() => Ok(await Send(new GetDashboardsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetDashboardByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetDashboardByIdQuery.Request request) => Ok(await Send(request));

        [Route("getDefault")]
        [HttpGet]
        [ResponseType(typeof(GetDefaultDashboardQuery.Response))]
        public async Task<IHttpActionResult> GetDefault() => Ok(await Send(new GetDefaultDashboardQuery.Request()));
        
        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveDashboardCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveDashboardCommand.Request request) => Ok(await Send(request));

    }
}

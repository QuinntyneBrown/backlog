using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Backlog.Features.Core;

namespace Backlog.Features.HomePages
{
    [Authorize]
    [RoutePrefix("api/homePages")]
    public class HomePageController : BaseApiController
    {
        public HomePageController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateHomePageCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateHomePageCommand.Request request) => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateHomePageCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateHomePageCommand.Request request) => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetHomePageQuery.Response))]
        public async Task<IHttpActionResult> Get() => Ok(await Send(new GetHomePageQuery.Request()));

        [Route("getAll")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetHomePagesQuery.Response))]
        public async Task<IHttpActionResult> GetAll() => Ok(await Send(new GetHomePagesQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetHomePageByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetHomePageByIdQuery.Request request) => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveHomePageCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveHomePageCommand.Request request) => Ok(await Send(request));

    }
}

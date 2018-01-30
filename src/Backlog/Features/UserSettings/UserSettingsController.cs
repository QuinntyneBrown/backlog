using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.UserSettings
{
    [Authorize]
    [RoutePrefix("api/usersettings")]
    public class UserSettingsController : BaseApiController
    {
        public UserSettingsController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateUserSettingsCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateUserSettingsCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateUserSettingsCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateUserSettingsCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetUserSettingssQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetUserSettingssQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetUserSettingsByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetUserSettingsByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveUserSettingsCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveUserSettingsCommand.Request request)
            => Ok(await Send(request));
    }
}

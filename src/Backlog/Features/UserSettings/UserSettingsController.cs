using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.UserSettings
{
    [Authorize]
    [RoutePrefix("api/userSettings")]
    public class UserSettingsController : ApiController
    {
        public UserSettingsController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateUserSettingsCommand.AddOrUpdateUserSettingsResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateUserSettingsCommand.AddOrUpdateUserSettingsRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateUserSettingsCommand.AddOrUpdateUserSettingsResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateUserSettingsCommand.AddOrUpdateUserSettingsRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetUserSettingssQuery.GetUserSettingssResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetUserSettingssQuery.GetUserSettingssRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetUserSettingsByIdQuery.GetUserSettingsByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetUserSettingsByIdQuery.GetUserSettingsByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveUserSettingsCommand.RemoveUserSettingsResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveUserSettingsCommand.RemoveUserSettingsRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}

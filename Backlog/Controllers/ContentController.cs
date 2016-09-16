using Backlog.ContentModels;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/content")]
    public class ContentController : ApiController
    {
        public ContentController(
            IAppShellContentModel appShellContentModel,
            ILandingPageContentModel landingPageContentModel
            )
        {
            _appShellContentModel = appShellContentModel;
            _landingPageConentModel = landingPageContentModel;            
        }

        [Route("appshell")]
        [HttpGet]
        [ResponseType(typeof(IAppShellContentModel))]
        public IHttpActionResult AppShell() => Ok(_appShellContentModel.Get());

        [Route("landing")]
        [HttpGet]
        [ResponseType(typeof(ILandingPageContentModel))]
        public IHttpActionResult LandingPage() => Ok(_landingPageConentModel.Get());

        protected readonly IAppShellContentModel _appShellContentModel;
        protected readonly ILandingPageContentModel _landingPageConentModel;
    }
}

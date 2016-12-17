using System.Web.Http;

namespace Backlog.Controllers
{
    [RoutePrefix("api/health")]
    public class HealthController: ApiController
    {
        [HttpGet]
        [Route("status")]
        public IHttpActionResult Status() => Ok();
    }
}

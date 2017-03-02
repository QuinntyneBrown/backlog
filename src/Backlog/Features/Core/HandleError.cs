using System.Web.Http.Filters;

namespace Backlog.Features.Core
{
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public HandleErrorAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Error");
        }

        public override void OnException(HttpActionExecutedContext context)
        {

        }

        protected readonly ILogger _logger;
    }
}



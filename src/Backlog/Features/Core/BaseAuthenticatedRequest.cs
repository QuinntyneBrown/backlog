namespace Backlog.Features.Core
{
    public class BaseAuthenticatedRequest : BaseRequest
    {
        public string Username { get; set; }
    }
}

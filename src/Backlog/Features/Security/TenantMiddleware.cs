using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using static Backlog.UnityConfiguration;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
using Microsoft.Owin;

namespace Backlog.Features.Security
{
    public class TenantMiddleware
    {
        AppFunc _next;

        public TenantMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var uri = new OwinContext(env).Request.Uri.Host;
            //var tenant = GetContainer().Resolve<IUserManager>().GetByUri(;
            env.Add("MultiTenant", "tenant");
            await _next.Invoke(env);
        }
    }
}
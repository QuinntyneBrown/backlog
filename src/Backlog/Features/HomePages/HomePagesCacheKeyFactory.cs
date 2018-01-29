using System;

namespace Backlog.Features.HomePages
{
    public class HomePagesCacheKeyFactory
    {
        public static string Get(Guid tenantId) => $"[HomePages] Get {tenantId}";
        public static string GetById(Guid tenantId, int id) => $"[HomePages] GetById {tenantId}-{id}";
    }
}

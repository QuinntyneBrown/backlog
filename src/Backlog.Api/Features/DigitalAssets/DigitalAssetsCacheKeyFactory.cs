using System;

namespace Backlog.Features.DigitalAssets
{
    public class DigitalAssetsCacheKeyFactory
    {
        public static string Get(Guid tenantId) => $"[DigitalAssets] Get {tenantId}";
        public static string GetById(Guid tenantId, int id) => $"[DigitalAssets] GetById {tenantId}-{id}";
        public static string GetByUniqueId(Guid tenantId, string uniqueId) => $"[DigitalAssets] GetByUniqueId {tenantId}-{uniqueId}";
    }
}

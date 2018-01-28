using Backlog.Features.DashboardTiles;
using Backlog.Model;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Features.Dashboards
{
    public class DashboardApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<DashboardTileApiModel> DashboardTiles { get; set; } = new HashSet<DashboardTileApiModel>();

        public static TModel FromDashboard<TModel>(Dashboard dashboard) where
            TModel : DashboardApiModel, new()
        {
            var model = new TModel();
            model.Id = dashboard.Id;
            model.TenantId = dashboard.TenantId;
            model.Name = dashboard.Name;
            model.DashboardTiles = dashboard.DashboardTiles.Select(x => DashboardTileApiModel.FromDashboardTile(x)).ToList();
            return model;
        }

        public static DashboardApiModel FromDashboard(Dashboard dashboard)
            => FromDashboard<DashboardApiModel>(dashboard);

    }
}

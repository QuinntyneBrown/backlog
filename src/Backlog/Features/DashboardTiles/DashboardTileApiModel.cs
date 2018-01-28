using Backlog.Features.Tiles;
using Backlog.Model;

namespace Backlog.Features.DashboardTiles
{
    public class DashboardTileApiModel
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string DashboardName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int? TileId { get; set; }
        public int? DashboardId { get; set; }
        public TileApiModel Tile { get; set; }
        public static TModel FromDashboardTile<TModel>(DashboardTile dashboardTile) where
            TModel : DashboardTileApiModel, new() => new TModel
            {
                Id = dashboardTile.Id,
                TenantId = dashboardTile.TenantId,
                Name = dashboardTile.Name,
                Width = dashboardTile.Width,
                Height = dashboardTile.Height,
                Top = dashboardTile.Top,
                Left = dashboardTile.Left,
                TileId = dashboardTile.TileId,
                DashboardId = dashboardTile.DashboardId,
                Tile = TileApiModel.FromTile(dashboardTile.Tile)

            };

        public static DashboardTileApiModel FromDashboardTile(DashboardTile dashboardTile)
            => FromDashboardTile<DashboardTileApiModel>(dashboardTile);
    }
}

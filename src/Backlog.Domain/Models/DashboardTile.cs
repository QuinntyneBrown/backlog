using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class DashboardTile
{
    public Guid DashboardTileId { get; set; }
    public string Name { get; set; }        
    [ForeignKey("Dashboard")]
    public Guid? DashboardId { get; set; }
    [ForeignKey("Tile")]
    public Guid? TileId { get; set; }
    public int Width { get; set; } = 1;
    public int Height { get; set; } = 1;
    public int Top { get; set; } = 1;
    public int Left { get; set; } = 1;
    public DateTime CreatedOn { get; set; }        
    public virtual Dashboard Dashboard { get; set; }
    public virtual Tile Tile { get; set; }
}

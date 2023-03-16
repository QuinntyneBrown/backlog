using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class Dashboard
{
    public Guid DashboardId { get; set; }		
    [ForeignKey("User")]
    public Guid? UserId { get; set; }
    public bool IsDefault { get; set; }
    public string Name { get; set; }
    public ICollection<DashboardTile> DashboardTiles { get; set; } = new HashSet<DashboardTile>();        
    public DateTime CreatedOn { get; set; }       
    public virtual User User { get; set; }
}

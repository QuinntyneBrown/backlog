using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backlog.Domain.Models;

public class EpicTheme
{
    public Guid EpicThemeId { get; set; }        
    [ForeignKey("Epic")]
    public Guid? EpicId { get; set; }
    [ForeignKey("Theme")]
    public Guid? ThemeId { get; set; }
    public Epic Epic { get; set; }
    public Theme Theme { get; set; }        
}

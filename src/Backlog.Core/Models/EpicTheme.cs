using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Core.Models
{
    
    public class EpicTheme
    {
        public Guid Id { get; set; }
        
        
        [ForeignKey("Epic")]
        public int? EpicId { get; set; }
        [ForeignKey("Theme")]
        public int? ThemeId { get; set; }
        public Epic Epic { get; set; }
        public Theme Theme { get; set; }
        
    }
}

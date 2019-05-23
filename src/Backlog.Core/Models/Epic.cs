
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    
    public class Epic: PrioritizableEntity
    {
        public override int Id { get; set; }
        
        
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Product Project { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public ICollection<EpicTheme> EpicThemes { get; set; } = new HashSet<EpicTheme>();
        public bool IsTemplate { get; set; }        
        

        
    }
}

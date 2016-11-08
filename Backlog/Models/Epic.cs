using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Models
{
    public class Epic
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Product Project { get; set; }
        public int? Priority { get; set; } = 0;
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public ICollection<EpicTheme> EpicThemes { get; set; } = new HashSet<EpicTheme>();
        public bool IsTemplate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

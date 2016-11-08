using System.Collections.Generic;

namespace Backlog.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Epic> Epics { get; set; } = new HashSet<Epic>();
        public bool IsDeleted { get; set; }
    }
}

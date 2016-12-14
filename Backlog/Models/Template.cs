using System.Collections.Generic;

namespace Backlog.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}

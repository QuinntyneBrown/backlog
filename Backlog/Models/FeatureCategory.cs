using System.Collections.Generic;

namespace Backlog.Models
{
    public class FeatureCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Feature> Features { get; set; } = new HashSet<Feature>();
    }
}

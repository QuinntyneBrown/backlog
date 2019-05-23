using System.Collections.Generic;


namespace Backlog.Core.Models
{
    
    public class FeatureCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Feature> Features { get; set; } = new HashSet<Feature>();
    }
}

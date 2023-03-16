using System;
using System.Collections.Generic;


namespace Backlog.Domain.Models;

public class FeatureCategory
{
    public Guid FeatureCategoryId { get; set; }
    public string Name { get; set; }        
    public ICollection<Feature> Features { get; set; } = new HashSet<Feature>();
}

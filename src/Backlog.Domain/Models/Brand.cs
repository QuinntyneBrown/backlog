using System;
using System.Collections.Generic;


namespace Backlog.Domain.Models;

public class Brand
{
    public Guid BrandId { get; set; }                
    public Guid? TemplateId { get; set; }
    public Template Template { get; set; }
    public string Name { get; set; }
    public ICollection<BrandOwner> BrandOwners { get; set; } = new HashSet<BrandOwner>();
    public ICollection<BrandFeature> BrandFeatures { get; set; } = new HashSet<BrandFeature>();                
}

using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;


public class Sprint
{
    public Guid SprintId { get; set; }        
    public string Name { get; set; }
    public ICollection<ProductSprint> ProductSprints { get; set; } = new HashSet<ProductSprint>();
    public ICollection<SprintStory> SprintStories { get; set; } = new HashSet<SprintStory>();



}

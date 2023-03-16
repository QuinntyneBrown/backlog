using System.Collections.Generic;
using System;


namespace Backlog.Domain.Models;

public class Tag
{
    public Guid TagId { get; set; }        
    public string Name { get; set; }        
    public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();        
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string CreatedBy { get; set; }
    public string LastModifiedBy { get; set; }
}

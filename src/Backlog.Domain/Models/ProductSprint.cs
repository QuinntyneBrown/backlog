
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;


public class ProductSprint
{
    public Guid ProductSprintId { get; set; }        
    public string Name { get; set; }
    public Guid? ProductId { get; set; }
    public Product Product { get; set; }
    public Guid? SprintId { get; set; }
    public Sprint Sprint { get; set; }



}

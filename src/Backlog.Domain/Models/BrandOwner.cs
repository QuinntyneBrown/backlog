using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class BrandOwner
{
    public Guid BrandOwnerId { get; set; }
    [ForeignKey("Brand")]
    public Guid? BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Name { get; set; }                
}

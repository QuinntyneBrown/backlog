using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;


public class Project
{
    public Guid ProjectId { get; set; }


    [Column(TypeName = "VARCHAR")]
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string CreatedBy { get; set; }
    public string LastModifiedBy { get; set; }



}

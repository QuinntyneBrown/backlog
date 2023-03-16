using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class SocialMediaAccount
{
    public Guid SocialMediaAccountId { get; set; }
    public string Name { get; set; }

    [ForeignKey("Profile")]
    public Guid? ProfileId { get; set; }
    [ForeignKey("User")]
    public Guid? UserId { get; set; }

    [Column(TypeName = "VARCHAR")]     
    [StringLength(255)]		   
    public string Title { get; set; }
    public DateTime CreatedOn { get; set; }        
    public User User { get; set; }
    public Profile Profile { get; set; }
}

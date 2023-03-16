using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backlog.Domain.Models;

public class Author
{
    public Guid AuthorId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string AvatarUrl { get; set; }        
}

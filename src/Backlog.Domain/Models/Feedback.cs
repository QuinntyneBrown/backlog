using System;


namespace Backlog.Domain.Models;

public class Feedback
{
    public Guid FeedbackId { get; set; }        
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;        
}

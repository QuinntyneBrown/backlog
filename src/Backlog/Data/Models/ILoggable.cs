using System;

namespace Backlog.Data.Models
{
    public interface ILoggable
    {
        DateTime CreatedOn { get; set; }
        DateTime LastModifiedOn { get; set; }
        string CreatedBy { get; set; }
        string LastModifiedBy { get; set; }
    }
}

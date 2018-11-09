namespace Backlog.Core.Models
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}

namespace Backlog.Data.Models
{
    public interface IPrioritizable
    {
        int Id { get; set; }
        int? Priority { get; set; }
    }
}

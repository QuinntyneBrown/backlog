using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}

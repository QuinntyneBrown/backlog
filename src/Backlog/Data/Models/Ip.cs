using Backlog.Data.Helpers;

namespace Backlog.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Ip
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

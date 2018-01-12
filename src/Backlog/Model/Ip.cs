using Backlog.Data.Helpers;

namespace Backlog.Model
{
    [SoftDelete("IsDeleted")]
    public class Ip
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

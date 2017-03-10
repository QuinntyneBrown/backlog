using Backlog.Data.Helpers;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Ip
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

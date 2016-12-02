using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}

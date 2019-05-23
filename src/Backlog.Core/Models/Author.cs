using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Core.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AvatarUrl { get; set; }        
    }
}

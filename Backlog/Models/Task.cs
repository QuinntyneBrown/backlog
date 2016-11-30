using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Models
{
    public class Task
    {
        public int Id { get; set; }
        [ForeignKey("Story")]
        public int? StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Story Story { get; set; }
        public bool IsDeleted { get; set; }
    }
}

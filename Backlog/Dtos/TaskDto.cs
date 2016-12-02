using Backlog.Models;
using System;

namespace Backlog.Dtos
{
    public class TaskDto
    {
        public TaskDto(Task entity)
        {
            Id = entity.Id;
            StoryId = entity.StoryId;
            Name = entity.Name;
            Description = entity.Description;
            StartDate = entity.StartDate;
            CompletedDate = entity.CompletedDate;
        }

        public TaskDto()
        {
            
        }

        public int Id { get; set; }
        public int? StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

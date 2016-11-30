using Backlog.Models;
using System;

namespace Backlog.Dtos
{
    public class TaskDto
    {
        public TaskDto(Task entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            CompletedDate = entity.CompletedDate;
        }

        public TaskDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

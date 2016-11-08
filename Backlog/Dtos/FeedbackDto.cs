using System;

namespace Backlog.Dtos
{
    public class FeedbackDto
    {
        public FeedbackDto(Backlog.Models.Feedback entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.EmailAddress = entity.EmailAddress;
            this.Description = entity.Description;
            this.CreatedDate = entity.CreatedDate;
        }

        public FeedbackDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

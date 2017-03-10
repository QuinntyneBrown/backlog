using Backlog.Data.Model;
using System;

namespace Backlog.Features.Stories
{
    public class StoryApiModel
    {        
        public int Id { get; set; }
        public int? EpicId { get; set; }
        public bool IsReusable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public int? Points { get; set; }
        public int? ArchitecturePoints { get; set; }
        public string Notes { get; set; }
        public int? Priority { get; set; }
        public DateTime? CompletedDate { get; set; }

        public static TModel FromStory<TModel>(Story story) where
            TModel : StoryApiModel, new()
        {
            var model = new TModel();
            model.Id = story.Id;
            model.EpicId = story.EpicId;
            model.IsReusable = story.IsReusable;
            model.Name = story.Name;
            model.Description = story.Description;
            model.AcceptanceCriteria = story.AcceptanceCriteria;
            model.Points = story.Points;
            model.ArchitecturePoints = story.ArchitecturePoints;
            model.Notes = story.Notes;
            model.Priority = story.Priority;
            model.CompletedDate = story.CompletedDate;
            return model;
        }

        public static StoryApiModel FromStory(Story story)
            => FromStory<StoryApiModel>(story);
    }
}

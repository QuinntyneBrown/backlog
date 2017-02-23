using Backlog.Models;

namespace Backlog.ApiModels
{
    public class StoryApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromStory<TModel>(Story story) where
            TModel : StoryApiModel, new()
        {
            var model = new TModel();
            model.Id = story.Id;
            return model;
        }
    }
}

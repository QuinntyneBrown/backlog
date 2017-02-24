using Backlog.Data.Models;

namespace Backlog.Features.Sprints
{
    public class SprintApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromSprint<TModel>(Sprint sprint) where
            TModel : SprintApiModel, new()
        {
            var model = new TModel();
            model.Id = sprint.Id;
            return model;
        }

        public static SprintApiModel FromSprint(Sprint sprint)
            => FromSprint<SprintApiModel>(sprint);

    }
}

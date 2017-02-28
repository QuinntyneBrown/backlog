using Backlog.Data.Models;

namespace Backlog.Features.Epics
{
    public class EpicApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromEpic<TModel>(Epic epic) where
            TModel : EpicApiModel, new()
        {
            var model = new TModel();
            model.Id = epic.Id;
            return model;
        }

        public static EpicApiModel FromEpic(Epic epic)
            => FromEpic<EpicApiModel>(epic);
    }
}
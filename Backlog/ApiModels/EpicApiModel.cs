using Backlog.Models;

namespace Backlog.ApiModels
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
    }
}

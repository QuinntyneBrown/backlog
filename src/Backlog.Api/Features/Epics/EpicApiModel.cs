using Backlog.Model;
using Backlog.Features.Products;
using Backlog.Features.Stories;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Features.Epics
{
    public class EpicApiModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int? Priority { get; set; }
        public ProductApiModel Product { get; set; }
        public ICollection<StoryApiModel> Stories { get; set; } = new HashSet<StoryApiModel>();

        public static TModel FromEpic<TModel>(Epic epic) where
            TModel : EpicApiModel, new()
        {
            var model = new TModel();
            model.Id = epic.Id;
            model.Name = epic.Name;
            model.ProductId = epic.ProductId;
            model.Description = epic.Description;
            model.Stories = epic.Stories.Where(s => !s.IsDeleted)
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority)
                .Select(x => StoryApiModel.FromStory(x)).ToList();
            model.Priority = epic.Priority;
            model.Product = ProductApiModel.FromProduct(epic.Product);

            return model;
        }

        public static EpicApiModel FromEpic(Epic epic)
            => FromEpic<EpicApiModel>(epic);
    }
}
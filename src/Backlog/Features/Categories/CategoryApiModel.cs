using Backlog.Model;

namespace Backlog.Features.Categories
{
    public class CategoryApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromCategory<TModel>(Category category) where
            TModel : CategoryApiModel, new()
        {
            var model = new TModel();
            model.Id = category.Id;
            return model;
        }

        public static CategoryApiModel FromCategory(Category category)
            => FromCategory<CategoryApiModel>(category);

    }
}

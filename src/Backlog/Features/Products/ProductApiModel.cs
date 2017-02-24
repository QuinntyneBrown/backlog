using Backlog.Data.Models;

namespace Backlog.Features.Products
{
    public class ProductApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromProduct<TModel>(Product product) where
            TModel : ProductApiModel, new()
        {
            var model = new TModel();
            model.Id = product.Id;
            return model;
        }

        public static ProductApiModel FromProduct(Product product)
            => FromProduct<ProductApiModel>(product);

    }
}

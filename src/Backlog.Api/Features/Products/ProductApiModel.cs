using Backlog.Model;
using Backlog.Features.Epics;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Features.Products
{
    public class ProductApiModel
    {        
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<EpicApiModel> Epics { get; set; }

        public static TModel FromProduct<TModel>(Product product) where
            TModel : ProductApiModel, new()
        {
            if (product == null) return null;

            var model = new TModel();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Slug = product.Slug;
            model.Epics = product.Epics.Select(x => EpicApiModel.FromEpic(x)).ToList();
            return model;
        }

        public static ProductApiModel FromProduct(Product product)
            => FromProduct<ProductApiModel>(product);
    }
}

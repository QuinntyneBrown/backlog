using Backlog.Model;

namespace Backlog.Features.Brands
{
    public class BrandApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromBrand<TModel>(Brand brand) where
            TModel : BrandApiModel, new()
        {
            var model = new TModel();
            model.Id = brand.Id;
            return model;
        }

        public static BrandApiModel FromBrand(Brand brand)
            => FromBrand<BrandApiModel>(brand);

    }
}

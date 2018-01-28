using Backlog.Model;
using System.Collections.Generic;
using System.Linq;

namespace Backlog.Features.HomePages
{
    public class HomePageApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<LinkApiModel> Links { get; set; } = new HashSet<LinkApiModel>();
        public string AvatarImageUrl { get; set; }
        public string Title { get; set; }
        public static TModel FromHomePage<TModel>(HomePage homePage) where
            TModel : HomePageApiModel, new()
        {
            var model = new TModel();
            model.Id = homePage.Id;
            model.Name = homePage.Name;
            model.AvatarImageUrl = homePage.AvatarImageUrl;
            model.Title = homePage.Title;
            model.Links = homePage.Links.Select(x => LinkApiModel.FromLink(x)).ToList();
            return model;
        }

        public static HomePageApiModel FromHomePage(HomePage homePage)
            => FromHomePage<HomePageApiModel>(homePage);

    }
}

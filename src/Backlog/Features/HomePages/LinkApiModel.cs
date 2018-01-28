using Backlog.Model;

namespace Backlog.Features.HomePages
{
    public class LinkApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Url { get; set; }
        public string DisplayText { get; set; }

        public static TModel FromLink<TModel>(Link link) where
            TModel : LinkApiModel, new()
        {
            var model = new TModel();
            model.Id = link.Id;
            model.TenantId = link.TenantId;
            model.Url = link.Url;
            model.DisplayText = link.DisplayText;
            return model;
        }

        public static LinkApiModel FromLink(Link link)
            => FromLink<LinkApiModel>(link);

    }
}

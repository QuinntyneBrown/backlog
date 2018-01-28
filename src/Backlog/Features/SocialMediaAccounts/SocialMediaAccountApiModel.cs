using Backlog.Model;

namespace Backlog.Features.SocialMediaAccounts
{
    public class SocialMediaAccountApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromSocialMediaAccount<TModel>(SocialMediaAccount socialMediaAccount) where
            TModel : SocialMediaAccountApiModel, new()
        {
            var model = new TModel();
            model.Id = socialMediaAccount.Id;
            model.TenantId = socialMediaAccount.TenantId;
            model.Name = socialMediaAccount.Name;
            return model;
        }

        public static SocialMediaAccountApiModel FromSocialMediaAccount(SocialMediaAccount socialMediaAccount)
            => FromSocialMediaAccount<SocialMediaAccountApiModel>(socialMediaAccount);

    }
}

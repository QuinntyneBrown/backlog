using Backlog.Features.Profiles;
using Backlog.Model;

namespace Backlog.Features.Users
{
    public class UserApiModel
    {        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public ProfileApiModel Profile { get; set; }
        public static TModel FromUser<TModel>(User user) where
            TModel : UserApiModel, new()
        {
            var model = new TModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Username = user.Username;
            model.Profile = ProfileApiModel.FromProfile(user.Profile);
            return model;
        }

        public static UserApiModel FromUser(User user)
            => FromUser<UserApiModel>(user);

    }
}

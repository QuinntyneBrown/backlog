using Backlog.Model;

namespace Backlog.Features.UserSettings
{
    public class UserSettingsApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromUserSettings<TModel>(Model.UserSettings userSettings) where
            TModel : UserSettingsApiModel, new()
        {
            var model = new TModel();
            model.Id = userSettings.Id;
            return model;
        }

        public static UserSettingsApiModel FromUserSettings(Model.UserSettings userSettings)
            => FromUserSettings<UserSettingsApiModel>(userSettings);

    }
}

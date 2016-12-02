namespace Backlog.Dtos
{
    public class UserSettingsAddOrUpdateResponseDto: UserSettingsDto
    {
        public UserSettingsAddOrUpdateResponseDto(Backlog.Models.UserSettings entity)
            :base(entity)
        {

        }
    }
}

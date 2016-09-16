namespace Backlog.Dtos
{
    public class UserAddOrUpdateResponseDto: UserDto
    {
        public UserAddOrUpdateResponseDto(Backlog.Models.User entity)
            :base(entity)
        {

        }
    }
}

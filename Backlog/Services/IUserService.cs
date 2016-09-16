using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IUserService
    {
        UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request);
        ICollection<UserDto> Get();
        UserDto GetById(int id);
        dynamic Remove(int id);
        UserDto Current(string username);
    }
}

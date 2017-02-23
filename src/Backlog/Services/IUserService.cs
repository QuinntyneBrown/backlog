using Backlog.ApiModels;
using Backlog.Requests;
using Backlog.Responses;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IUserService
    {
        UserAddOrUpdateResponse AddOrUpdate(UserAddOrUpdateRequest request);
        ICollection<UserApiModel> Get();
        UserApiModel GetById(int id);
        dynamic Remove(int id);
        UserApiModel Current(string username);
        dynamic Register(RegistrationRequest request, IList<string> roles);
    }
}

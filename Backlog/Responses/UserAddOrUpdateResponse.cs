using Backlog.ApiModels;
using Backlog.Models;

namespace Backlog.Responses
{
    public class UserAddOrUpdateResponse: UserApiModel
    {
        public UserAddOrUpdateResponse(User entity)
            :base(entity)
        {

        }
    }
}

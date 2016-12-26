using Backlog.Models;

namespace Backlog.ApiModels
{
    public class UserApiModel
    {
        public UserApiModel(User entity)
        {
            Id = entity.Id;
            Username = entity.Username;
        }

        public UserApiModel()
        {

        }

        public int Id { get; set; }
        public string Username { get; set; }
    }
}

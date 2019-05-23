using Backlog.Model;

namespace Backlog.Features.AgileTeams
{
    public class AgileTeamMemberApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromAgileTeamMember<TModel>(AgileTeamMember agileTeamMember) where
            TModel : AgileTeamMemberApiModel, new()
        {
            var model = new TModel();
            model.Id = agileTeamMember.Id;
            return model;
        }

        public static AgileTeamMemberApiModel FromAgileTeamMember(AgileTeamMember agileTeamMember)
            => FromAgileTeamMember<AgileTeamMemberApiModel>(agileTeamMember);

    }
}

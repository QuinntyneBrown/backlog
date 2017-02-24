using Backlog.Data.Models;

namespace Backlog.Features.AgileTeams
{
    public class AgileTeamApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromAgileTeam<TModel>(AgileTeam agileTeam) where
            TModel : AgileTeamApiModel, new()
        {
            var model = new TModel();
            model.Id = agileTeam.Id;
            return model;
        }

        public static AgileTeamApiModel FromAgileTeam(AgileTeam agileTeam)
            => FromAgileTeam<AgileTeamApiModel>(agileTeam);

    }
}

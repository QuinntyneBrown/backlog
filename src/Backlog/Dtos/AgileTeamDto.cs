namespace Backlog.Dtos
{
    public class AgileTeamDto
    {
        public AgileTeamDto(Backlog.Models.AgileTeam entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public AgileTeamDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

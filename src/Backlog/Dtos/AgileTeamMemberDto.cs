namespace Backlog.Dtos
{
    public class AgileTeamMemberDto
    {
        public AgileTeamMemberDto(Backlog.Models.AgileTeamMember entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public AgileTeamMemberDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

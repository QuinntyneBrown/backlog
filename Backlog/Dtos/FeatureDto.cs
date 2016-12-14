namespace Backlog.Dtos
{
    public class FeatureDto
    {
        public FeatureDto(Backlog.Models.Feature entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public FeatureDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

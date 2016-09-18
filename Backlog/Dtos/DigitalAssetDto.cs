namespace Backlog.Dtos
{
    public class DigitalAssetDto
    {
        public DigitalAssetDto(Backlog.Models.DigitalAsset entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            RelativeUrl = entity.RelativePath;
        }

        public DigitalAssetDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RelativeUrl { get; set; }
    }
}

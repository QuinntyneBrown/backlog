namespace Backlog.Dtos
{
    public class BrandOwnerDto
    {
        public BrandOwnerDto(Backlog.Models.BrandOwner entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public BrandOwnerDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

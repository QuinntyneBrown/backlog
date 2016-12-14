using System.Collections.Generic;

namespace Backlog.Dtos
{
    public class BrandDto
    {
        public BrandDto(Backlog.Models.Brand entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            TemplateId = entity.TemplateId;
        }

        public BrandDto() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TemplateId { get; set; }
        public TemplateDto Template { get; set; }
        public ICollection<FeatureDto> Features { get; set; } = new HashSet<FeatureDto>();
        public ICollection<BrandOwnerDto> BrandOwners { get; set; } = new HashSet<BrandOwnerDto>();
    }
}

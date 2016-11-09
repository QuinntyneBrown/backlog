using System.Collections.Generic;
using System.Linq;

namespace Backlog.Dtos
{
    public class ProductDto
    {
        public ProductDto(Backlog.Models.Product entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Epics = entity.Epics.Select(x => new EpicDto(x)).ToList();
        }

        public ProductDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EpicDto> Epics { get; set; } = new HashSet<EpicDto>();
    }
}

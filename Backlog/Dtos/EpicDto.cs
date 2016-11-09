using Backlog.Models;
using System.Collections.Generic;
using System.Linq;
namespace Backlog.Dtos
{
    public class EpicDto
    {
        public EpicDto(Epic entity)
        {
            Id = entity.Id;
            ProductId = entity.ProductId;
            Name = entity.Name;
            Description = entity.Description;
            Stories = entity.Stories.Where(s=>!s.IsDeleted)
                .OrderBy(x=>x.Name)
                .OrderByDescending(x=>x.Priority)
                .Select(x => new StoryDto(x)).ToList();
            Priority = entity.Priority;
            Product = new ProductDto(entity.Product);
        }

        public EpicDto() { }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int? Priority { get; set; }
        public ProductDto Product { get; set; }
        public ICollection<StoryDto> Stories { get; set; } = new HashSet<StoryDto>();
    }
}

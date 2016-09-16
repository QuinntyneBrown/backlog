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
            Name = entity.Name;
            Stories = entity.Stories.Select(x => new StoryDto(x)).ToList();
        }

        public EpicDto() { }

        public int Id { get; set; }        
        public string Name { get; set; }
        public ICollection<StoryDto> Stories { get; set; } = new HashSet<StoryDto>();
    }
}

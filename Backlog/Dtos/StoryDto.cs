using Backlog.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Web.HttpUtility;

namespace Backlog.Dtos
{
    public class StoryDto
    {
        public StoryDto(Story entity)
        {
            Id = entity.Id;
            Name = entity.Name;            
            Description = entity.Description;
            EpicId = entity.EpicId;
            IsReusable = entity.IsReusable;
            Priority = entity.Priority;
            AcceptanceCriteria = entity.AcceptanceCriteria;
            Notes = entity.Notes;
            DigitalAssets = entity.StoryDigitalAssets.Select(x => new DigitalAssetDto(x.DigitalAsset)).ToList();
        }

        public StoryDto() { }

        public int Id { get; set; }
        public int? EpicId { get; set; }
        public bool IsReusable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string Notes { get; set; }
        public int? Priority { get; set; }
        public EpicDto Epic { get; set; }
        public ICollection<DigitalAssetDto> DigitalAssets = new HashSet<DigitalAssetDto>();
    }
}

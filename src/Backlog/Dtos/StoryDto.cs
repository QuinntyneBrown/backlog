using Backlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Points = entity.Points;
            CompletedDate = entity.CompletedDate;
            ArchitecturePoints = entity.ArchitecturePoints;            
            DigitalAssets = entity.StoryDigitalAssets.Where(x=>!x.DigitalAsset.IsDeleted).Select(x => new DigitalAssetDto(x.DigitalAsset)).ToList();
        }

        public StoryDto() { }

        public int Id { get; set; }
        public int? EpicId { get; set; }
        public bool IsReusable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public int? Points { get; set; }
        public int? ArchitecturePoints { get; set; }
        public string Notes { get; set; }
        public int? Priority { get; set; }
        public DateTime? CompletedDate { get; set; }
        public EpicDto Epic { get; set; }
        public ICollection<DigitalAssetDto> DigitalAssets = new HashSet<DigitalAssetDto>();
    }
}
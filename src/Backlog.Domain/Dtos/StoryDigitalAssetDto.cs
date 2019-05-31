using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class StoryDigitalAssetDtoValidator: AbstractValidator<StoryDigitalAssetDto>
    {
        public StoryDigitalAssetDtoValidator()
        {
            RuleFor(x => x.StoryDigitalAssetId).NotNull();
        }
    }

    public class StoryDigitalAssetDto
    {        
        public Guid StoryDigitalAssetId { get; set; }
    }

    public static class StoryDigitalAssetExtensions
    {        
        public static StoryDigitalAssetDto ToDto(this StoryDigitalAsset storyDigitalAsset)
            => new StoryDigitalAssetDto
            {
                StoryDigitalAssetId = storyDigitalAsset.StoryDigitalAssetId
            };
    }
}

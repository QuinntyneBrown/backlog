using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IFeatureService
    {
        FeatureAddOrUpdateResponseDto AddOrUpdate(FeatureAddOrUpdateRequestDto request);
        ICollection<FeatureDto> Get();
        FeatureDto GetById(int id);
        dynamic Remove(int id);
    }
}

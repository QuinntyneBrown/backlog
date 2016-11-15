using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IDigitalAssetService
    {
        DigitalAssetAddOrUpdateResponseDto AddOrUpdate(DigitalAssetAddOrUpdateRequestDto request);
        ICollection<DigitalAssetDto> Get();
        DigitalAssetDto GetById(int id);
        dynamic Remove(int? id, string relativeUrl);
    }
}

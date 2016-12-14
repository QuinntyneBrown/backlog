using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IBrandService
    {
        BrandAddOrUpdateResponseDto AddOrUpdate(BrandAddOrUpdateRequestDto request);
        ICollection<BrandDto> Get();
        BrandDto GetById(int id);
        dynamic Remove(int id);
    }
}

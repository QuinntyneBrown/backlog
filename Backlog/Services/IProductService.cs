using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IProductService
    {
        ProductAddOrUpdateResponseDto AddOrUpdate(ProductAddOrUpdateRequestDto request);
        ICollection<ProductDto> Get();
        ProductDto GetById(int id);
        dynamic Remove(int id);
    }
}

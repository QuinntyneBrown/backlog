using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IAuthorService
    {
        AuthorAddOrUpdateResponseDto AddOrUpdate(AuthorAddOrUpdateRequestDto request);
        ICollection<AuthorDto> Get();
        AuthorDto GetById(int id);
        dynamic Remove(int id);
    }
}

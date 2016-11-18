using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IArticleService
    {
        ArticleAddOrUpdateResponseDto AddOrUpdate(ArticleAddOrUpdateRequestDto request);
        ICollection<ArticleDto> Get();
        ArticleDto GetById(int id);
        dynamic Remove(int id);
    }
}

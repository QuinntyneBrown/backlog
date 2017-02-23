using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IProjectService
    {
        ProjectAddOrUpdateResponseDto AddOrUpdate(ProjectAddOrUpdateRequestDto request);
        ICollection<ProjectDto> Get();
        ProjectDto GetById(int id);
        dynamic Remove(int id);
    }
}

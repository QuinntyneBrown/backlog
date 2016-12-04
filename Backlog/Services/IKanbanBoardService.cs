using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IKanbanBoardService
    {
        KanbanBoardDto Get();
    }
}

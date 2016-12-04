using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Dtos
{
    public class KanbanBoardDto
    {
        public ICollection<KanbanBoardStoryDto> Stories { get; set; } = new HashSet<KanbanBoardStoryDto>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Dtos
{
    public class KanbanBoardStoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public ICollection<KanbanBoardTaskDto> Tasks { get; set; }
    }
}

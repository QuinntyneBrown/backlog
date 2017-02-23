using Backlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Dtos
{
    public class KanbanBoardTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public KanbanBoardTaskStatus Status { get; set; }
    }
}

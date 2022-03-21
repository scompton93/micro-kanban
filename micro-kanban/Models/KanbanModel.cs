using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace micro_kanban.Models
{
    public class KanbanModel
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public string Content { get; set; }
    }
}

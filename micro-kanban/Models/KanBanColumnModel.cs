using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace micro_kanban.Models
{
    public class KanBanColumnModel
    {
        public KanBanColumnModel(int Id, List<KanbanModel> Items)
        {
            this.Id = Id;
            this.Items = Items;
        }
        public int Id { get; set; }
        public List<KanbanModel> Items { get; set; }
    }
}

using micro_kanban.Data;
using micro_kanban.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace micro_kanban.Pages.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        [HttpGet]
        public List<Models.KanBanColumnModel> Get()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var kanbanItems = sql.LoadData<KanbanModel, dynamic>("dbo.spGetItems", "ConnString");

            var kanbanResult = new List<KanBanColumnModel>();

            var columnList = kanbanItems.Select(o => o.Column).Distinct();
            foreach(var col in columnList)
            {
                kanbanResult.Add(new KanBanColumnModel(col, kanbanItems.Where(o => o.Column == col).ToList() ));
            }
            return kanbanResult;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody] KanbanModel value)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { ColumnId = value.Id, Content = value.Content };
            sql.SaveData("dbo.spInsertItem", p,"ConnString");
            Console.WriteLine("test");
        }
    }
}

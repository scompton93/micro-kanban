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
        public object Get()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var kanbanItems = sql.LoadData<KanbanModel, dynamic>("dbo.spGetItems", "ConnString");

            var kanbanResult = kanbanItems
                .Select(m => new { Id = m.Id, Column = m.Column, Content = m.Content })
                .GroupBy(m => m.Column)
                .Select(m => new { Id = m.Key, Items = m.ToList() })
                .ToList();
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
            sql.SaveData("dbo.spInsertItem", p, "ConnString");
            Console.WriteLine("test");
        }
    }
}

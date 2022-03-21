using micro_kanban.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var kanbanItems = sql.LoadData<Models.KanbanModel, dynamic>("dbo.spGetItems", "ConnString");

            var kanbanResult = new List<Models.KanBanColumnModel>();

            var columnList = kanbanItems.Select(o => o.Column).Distinct();
            foreach(var col in columnList)
            {
                kanbanResult.Add(new Models.KanBanColumnModel(col, kanbanItems.Where(o => o.Column == col).ToList() ));
            }
            return kanbanResult;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody] object value)
        {

            Console.WriteLine("test");
        }
    }
}

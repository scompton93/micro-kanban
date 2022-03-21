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
        public List<Models.KanbanModel> Get()
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<Models.KanbanModel, dynamic>("dbo.spGetItems", "ConnString");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Controllers;
using Newtonsoft.Json;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mostrarController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string sql = "";
            DB db = new DB();
            sql = "SELECT * FROM tareas WHERE id='"+id+"'";
            var data = db.conf(sql);
            //var tbls = data.Tables[0].Rows;
            return JsonConvert.SerializeObject(data);
        }
    }
}
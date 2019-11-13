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
    public class loginController : ControllerBase
    {
        [HttpPost]
        public string Post([FromForm] login Models)
        {
            string sql = "";
            DB db = new DB();
            sql = "SELECT usuario FROM login WHERE usuario='" + Models.usuario + "' AND paswword='"+Models.paswword+"'";
            var data = db.conf(sql);
            //var tbls = data.Tables[0].Rows;
            return JsonConvert.SerializeObject(data);
        }
    }

}
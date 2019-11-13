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
    public class consultarController : ControllerBase
    {
        [HttpGet("{id}/{usu}")]
        public ActionResult<string> Get(int id, int usu)
        {
            DB db = new DB();
            string sql = "";
            switch (id)
            {
                case 1:
                    sql = "SELECT * FROM tareas order by id";
                    break;
                case 2:
                    sql = "SELECT * FROM tareas WHERE idusuario='"+usu+ "' order by id;"; 
                    break;
                case 3:
                    sql = "SELECT * FROM tareas WHERE estado='si' order by id";
                    break;
                case 4:
                    sql = "SELECT * FROM tareas WHERE estado='no' order by id";
                    break;
                case 5:
                    sql = "SELECT * FROM tareas order by id"; 
                    break;
                case 6:
                    sql = "SELECT * FROM tareas WHERE idusuario='"+usu+ "' order by id;";
                    break;
                case 7:
                    sql = "SELECT * FROM tareas ORDER BY fechav,id ASC";
                    break;
                case 8:
                    sql = "SELECT * FROM tareas ORDER BY fechav,id DESC";
                    break;
                case 9:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='si' order by id";
                    break;
                case 10:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='no' order by id";
                    break;
                case 11:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='si'  ORDER BY fechav,id ASC"; 
                    break;
                case 12:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='si'  ORDER BY fechav,id DESC"; 
                    break;
                case 13:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='no'  ORDER BY fechav,id ASC";
                    break;
                case 14:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='no'  ORDER BY fechav,id DESC";
                    break;
                case 15:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='no'  ORDER BY fechac,id ASC";
                    break;
                case 16:
                    sql = "SELECT * FROM tareas WHERE idusuario='" + usu + "' AND estado='si'  ORDER BY fechac,id ASC";
                    break;

                default:

                    break;
            }
            var data = db.conf(sql);
            return JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Post([FromForm] tablamodels Models)
        {
            DB db = new DB();
            var sql = "INSERT INTO tareas(autor,fechac,estado,fechav,descripcion,idusuario) VALUES('" + Models.autor + "','" + Models.fechac + "','" + Models.estado + "','" + Models.fechav + "','" +Models.descripcion + "','" + Models.idusuario + "')";
            var guardar = db.insert(sql);
            return (guardar);
        }
        [HttpPut]
        public string Put([FromForm] tablamodels Models)
        {
            //tablamodels Models = new tablamodels();
            DB db = new DB();
            var sql = "UPDATE tareas SET  autor='" + Models.autor + "',fechac='" + Models.fechac + "',estado='" + Models.estado + "',fechav='" + Models.fechav + "',descripcion='" + Models.descripcion + "' WHERE id='" + Models.id + "'";
            var actu=db.update(sql);
            return (actu);
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            //tablamodels Models = new tablamodels();
            DB db = new DB();
            var sql = "DELETE FROM tareas WHERE id='" + id + "'";
            var data = db.delete(sql);
            return (data);
        }
    }
}
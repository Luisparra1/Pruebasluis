using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Newtonsoft.Json;
using System;

namespace Prueba.Controllers
{
    public class TareasController : Controller
    {
        public int usu;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult principal(int id)
        {
           
            ViewData["principal"] = id;
            return View();
        }

        public IActionResult consultar(int id)
        {
            ViewData["consultar"] = id;
            return View();
        }

        public IActionResult crear(int id)
        {
            ViewData["crear"] = id;
            string sql = "";
            DB db = new DB();
            tablamodels Models = new tablamodels();
            sql = "SELECT * FROM tareas WHERE id='" + id + "'";
            var data = db.conf(sql);
            var tbls = data.Tables[0].Rows;
            var list = tbls.Add();
            var cantidad = list.Table.Rows.Count;
            for (int i = 0; i < list.Table.Rows.Count - 1; i++)
            {
                Models.autor = Convert.ToString(list.Table.Rows[i][3]);
            }
            ViewData["id"] = id;
            ViewData["autor"] = Models.autor;
            return View();
        }
        public IActionResult actualizar(int id,int ide)
        {
            ViewData["actualizar"] = ide;
            string sql = "";
            DB db = new DB();
            tablamodels Models = new tablamodels();
            sql = "SELECT * FROM tareas WHERE id='" + id + "'";
            var data = db.conf(sql);
            var tbls = data.Tables[0].Rows;
            var list = tbls.Add();
            var cantidad = list.Table.Rows.Count;
            for (int i = 0; i < list.Table.Rows.Count - 1; i++)
            {
                Models.descripcion = Convert.ToString(list.Table.Rows[i][1]);
                Models.estado = Convert.ToString(list.Table.Rows[i][2]);
                Models.autor = Convert.ToString(list.Table.Rows[i][3]);
                Models.idusuario = Convert.ToInt32(list.Table.Rows[i][4]);
                Models.fechac = Convert.ToString(list.Table.Rows[i][5]);
                Models.fechav = Convert.ToString(list.Table.Rows[i][6]);
            }
            ViewData["id"] =id;
            ViewData["descripcion"] = Models.descripcion;
            ViewData["estado"] = Models.estado;
            ViewData["autor"] = Models.autor;
            ViewData["idusuario"] = Models.idusuario;
            ViewData["fechac"] = Convert.ToDateTime(Models.fechac).ToString("yyyy-MM-dd");
            ViewData["fechav"] = Convert.ToDateTime(Models.fechav).ToString("yyyy-MM-dd");
            //var tbls = data.Tables[0].Rows;
            return View();
        }
        public IActionResult borrar(int id)
        {
            string sql = "";
            DB db = new DB();
            tablamodels Models = new tablamodels();
            sql = "SELECT * FROM tareas WHERE id='" + id + "'";
            var data = db.conf(sql);
            var tbls = data.Tables[0].Rows;
            var list = tbls.Add();
            var cantidad = list.Table.Rows.Count;
            for (int i = 0; i < list.Table.Rows.Count - 1; i++)
            {
                Models.descripcion = Convert.ToString(list.Table.Rows[i][1]);
                Models.estado = Convert.ToString(list.Table.Rows[i][2]);
                Models.autor = Convert.ToString(list.Table.Rows[i][3]);
                Models.idusuario = Convert.ToInt32(list.Table.Rows[i][4]);
                Models.fechac = Convert.ToString(list.Table.Rows[i][5]);
                Models.fechav = Convert.ToString(list.Table.Rows[i][6]);
            }
            ViewData["id"] = id;
            ViewData["descripcion"] = Models.descripcion;
            ViewData["estado"] = Models.estado;
            ViewData["autor"] = Models.autor;
            ViewData["idusuario"] = Models.idusuario;
            ViewData["fechac"] = Convert.ToDateTime(Models.fechac).ToString("yyyy-MM-dd");
            ViewData["fechav"] = Convert.ToDateTime(Models.fechav).ToString("yyyy-MM-dd");
            //var tbls = data.Tables[0].Rows;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

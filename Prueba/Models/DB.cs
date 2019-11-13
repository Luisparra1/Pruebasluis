using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class DB
    {
        private string coectastring;
        //public ImprimirLogs Implog;
        private readonly IConfiguration _configuration = BuildConfiguration();
        public DB()
        {
            // Implog = new ImprimirLogs();
            //coectastring = "Server=10.216.170.68;Port=5432;Database=bmo;User Id=bmo_user;Password=$idi123456;";
            coectastring = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        public string update(string sql)
        {
            try
            {
                using (var connection = new NpgsqlConnection(coectastring))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0" + ex.ToString();
                // Implog.CrearLog($"Error Fatal updateSQL---- {ex.Message} -");
            }
        }
        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public string insert(string sql)
        {
            try
            {
                using (var connection = new NpgsqlConnection(coectastring))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0" + ex.ToString();
                //Implog.CrearLog($"Error Fatal in sertSQL---- {ex.Message} -");
            }
        }

        public string delete(string sql)
        {
            try
            {
                using (var connection = new NpgsqlConnection(coectastring))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql,connection);
                    cmd.ExecuteScalar();
                    
                    connection.Close();

                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0" + ex.ToString();
                // Implog.CrearLog($"Error Fatal updateSQL---- {ex.Message} -");
            }
        }
       

        public System.Data.DataSet conf(string sql)
        {

            //Implog.CrearLog($"DBconf------------{coectastring}---{sql}");
            //string coectastring = "Server=186.28.253.110;Port=5432;Database=bmo;User Id=bmo_user;Password=t3mp0r4l2019;";
            using (var connection = new NpgsqlConnection(coectastring))
            {
                System.Data.DataSet ds2 = new System.Data.DataSet();
                try
                {
                    //connection.Open();
                    using (Npgsql.NpgsqlDataAdapter adapter = new Npgsql.NpgsqlDataAdapter(sql, connection))
                    {
                        connection.Open();

                        adapter.Fill(ds2);
                        connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    //Implog.CrearLog($"DBconf------------{ex.ToString()}");
                }
                return ds2;


            }
        }
    }

}

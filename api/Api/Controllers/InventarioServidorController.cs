using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioServidorController : ControllerBase
    {
        List<Servidor> servidores = new List<Servidor>();
        Servidor servidor = new Servidor();

        [HttpGet]
        [Route("{id}")]
        public Servidor HttpGetById(String id)
        {
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Servidor WHERE servidorId = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));

                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())

                        {
                            int servidorID = reader.GetInt32(0);
                            string ip = reader.GetString(1);
                            string hostname = reader.GetString(2);
                            string observacao = reader.GetString(3);
                            bool status = reader.GetBoolean(4);
                            string tipoServidor = reader.GetString(5);
                            int espacoDisco = reader.GetInt16(6);
                            int cpu = reader.GetInt16(7);
                            int memoria = reader.GetInt16(8);
                            string conteudo = reader.GetString(9);
                            servidor = new Servidor() { ServidorID = servidorID, IP = ip, Hostname = hostname, Observacao = observacao, Status = status, TipoServidor = tipoServidor, EspacoDisco = espacoDisco, Cpu = cpu, Memoria = memoria, Conteudo = conteudo };
                        }
                        return servidor;
                    }
                }
            }
        }

        [HttpGet]
        public List<Servidor> HttpGetAttribute()
        {
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Servidor", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int servidorID = reader.GetInt32(0);
                        string ip = reader.GetString(1);
                        string hostname = reader.GetString(2);
                        string observacao = reader.GetString(3);
                        bool status = reader.GetBoolean(4);
                        string tipoServidor = reader.GetString(5);
                        int espacoDisco = reader.GetInt16(6);
                        int cpu = reader.GetInt16(7);
                        int memoria = reader.GetInt16(8);
                        string conteudo = reader.GetString(9);
                        servidores.Add(new Servidor() { ServidorID = servidorID, IP = ip, Hostname = hostname, Observacao = observacao, Status = status, TipoServidor = tipoServidor, EspacoDisco = espacoDisco, Cpu = cpu, Memoria = memoria, Conteudo = conteudo });
                    }
                    reader.Close();
                    return servidores;
                }
            }
        }
    }
}

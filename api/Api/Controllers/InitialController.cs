using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Repository;
using Api.Repository.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InitialController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ServidorRepository _servidorRepository;
        public InitialController(SistemaInventarioContext context)
        {
            _usuarioRepository = new UsuarioRepositoryImpl(context);
            _servidorRepository = new ServidorRepositoryImpl(context);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Initiate()
        {
            var userAdmin = new Usuario() { Id = "1", Login = "Henrique", Senha = "1234" };
            _usuarioRepository.Cadastrar(userAdmin);

            /*_servidorRepository.Cadastrar(new Servidor() { ServidorId = 1, Ip = "123.123.123.12", Hostname = "Teste", Observacao = "Teste", Status = "Ativo" });
            _servidorRepository.Cadastrar(new Servidor() { ServidorId = 2, Ip = "123.123.123.12", Hostname = "Name", Observacao = "Teste", Status = "Ativo" });*/

            return Ok(new
            {
                Servidor = _servidorRepository.ListarTodos()
            });
        }
    }
}
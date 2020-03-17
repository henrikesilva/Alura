using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Repository;
using Api.Repository.Impl;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(SistemaInventarioContext context)
        {
            _usuarioRepository = new UsuarioRepositoryImpl(context);
        }

        [HttpPost]
        public ActionResult<dynamic> Login([FromBody] Usuario usuario)
        {
            try
            {
                var user = usuario.Login;
                var pass = usuario.Senha;

                if (user == null && pass == null)
                {
                    return NotFound(new { messge = "Usuario ou senha invalidos" });
                }

                var token = TokenService.GenerateToken(user, pass);
                return new
                {
                    login = usuario.Login,
                    token
                };
            }
            catch (Exception ex)
            {

                return BadRequest("Ocorreu um erro na solicitação, por gentileza contate o administrador do sistema" + ex);
            }
            
        }

    }
}
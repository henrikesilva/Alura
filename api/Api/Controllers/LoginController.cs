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
        public async Task<ActionResult<dynamic>> Login([FromBody] Usuario usuario)
        {
            var user = _usuarioRepository.BuscarUsuario(usuario.Login, usuario.Senha);

            if (user == null)
            {
                return NotFound(new { messge = "Usuario ou senha invalidos" });
            }

            var token = TokenService.GenerateToken(user);
            return new
            {
                login = usuario.Login,
                token
            };
        }

    }
}
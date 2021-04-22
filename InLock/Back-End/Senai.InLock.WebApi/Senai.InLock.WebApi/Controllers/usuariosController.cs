using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private IUsuarioRepositories _usuarioRepository { get; set; }

        public usuariosController()
        {
            _usuarioRepository = new usuariosRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(usuariosDomain login)
        {
            usuariosDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            return Ok(usuarioBuscado);
        }

    }
}

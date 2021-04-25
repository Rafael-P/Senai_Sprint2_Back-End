using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

            //Caso encontre, prossegue para a criação do token
            var claims = new[]
            {
                                          //TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Salve Rapaziada")
            };

            //Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            //Define as credenciais do token - Header 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Define a composição do token
            var token = new JwtSecurityToken(
               issuer : "InLock.WebApi",                //emissor do token
               audience : "InLock.WebApi",              //destinatario do token
               claims : claims,                         //dados definidos acima(linha 59)
               expires : DateTime.Now.AddMinutes(30),   //tempo de expiração
               signingCredentials : creds               //credenciais do token
            );

            //Retorna um status code 200 - Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}

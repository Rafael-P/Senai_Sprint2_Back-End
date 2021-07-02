using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_SPMedicalGroup_webApi.Domains;
using Senai_SPMedicalGroup_webApi.Interfaces;
using Senai_SPMedicalGroup_webApi.Repositories;
using Senai_SPMedicalGroup_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Controllers
{
    /// <summary>
    /// Controller responsavel pelos endpoints referentes ao Login
    /// </summary>
     
    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisicao sera no formato dominio/api/NomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {

        /// <summary>
        /// Cria um objeto _usuarioRepository que ira receber todos os metodos definidos na interface 
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referencia aos metodos no repositorio
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="login"> Objeto login que contem o e-mail e a senha do usuario </param>
        /// <returns> Retorna um token com as informações do usuario </returns>
        /// dominio/api/Login
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //busca o usuario pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                //Caso nao encontre nenhum usuario com o email e senha infromados
                if (usuarioBuscado == null)
                {
                    //retorna um notfound com uma mensagem
                    return NotFound("E-mail ou senha inválidos!");
                }

                //Caso o usuario seja encontrado, prossegue para a criaçao do token

                /*
                    Dependências

                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Medico ou Paciente)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Medico ou Paciente) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                    //new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)
                };

                //Define a cheve de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                //Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "spmg.webApi",                      //emissor do token
                    audience: "spmg.webApi",                    //destinatario do token
                    claims: claims,                             //dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),       //tempo de expiração
                    signingCredentials: creds                   //credenciais do token
                );

                //retorna OK com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

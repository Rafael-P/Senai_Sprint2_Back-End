using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedicalGroup_webApi.Domains;
using Senai_SPMedicalGroup_webApi.Interfaces;
using Senai_SPMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os metodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuariosRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuariosRepository para que haja a referencia aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuariosRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 200 - ok
                return Ok(_usuariosRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>Um usuario e um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //200 - Ok
                return Ok(_usuariosRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto que sera cadastrado</param>
        /// <returns>Um status code Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuariosRepository.Cadastrar(novoUsuario);

                // 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuariosRepository.Atualizar(id, usuarioAtualizado);

                // NoContent - 204
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // BadRequest - 400
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>UM status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuariosRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

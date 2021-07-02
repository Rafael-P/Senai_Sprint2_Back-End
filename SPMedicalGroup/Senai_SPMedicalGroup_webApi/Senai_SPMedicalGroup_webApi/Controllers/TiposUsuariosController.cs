using Microsoft.AspNetCore.Authorization;
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

    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes as tpUsuario
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tpUsuario
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que qualquer usuário autenticado pode acessar aos métodos
    [Authorize]

    public class TiposUsuariosController : ControllerBase
    {

        /// <summary>
        /// Objeto _tpUsuarioRepository que irá receber todos os métodos definidos na interface ITiposUsuariosRepository
        /// </summary>
        private ITiposUsuarioRepository _tpUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tpUsuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposUsuariosController()
        {
            _tpUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tpUsuario
        /// </summary>
        /// <returns>Uma lista de tpUsuario e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 200 - ok
                return Ok(_tpUsuarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tpUsuario pelo seu id
        /// </summary>
        /// <param name="id">id do tpUsuario</param>
        /// <returns>Um tpUsuario um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //200 - Ok
                return Ok(_tpUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo tpUsuario
        /// </summary>
        /// <param name="novoTpUsuario">Objeto que sera cadastrado</param>
        /// <returns>Um status code Created</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTpUsuario)
        {
            try
            {
                _tpUsuarioRepository.Cadastrar(novoTpUsuario);

                // 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tpUsuario
        /// </summary>
        /// <param name="id">id do tpUsuario</param>
        /// <param name="tpUsuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tpUsuarioAtualizado)
        {
            try
            {
                _tpUsuarioRepository.Atualizar(id, tpUsuarioAtualizado);

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
        /// Deleta um tpUsuario
        /// </summary>
        /// <param name="id">id do tpUsuario</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tpUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

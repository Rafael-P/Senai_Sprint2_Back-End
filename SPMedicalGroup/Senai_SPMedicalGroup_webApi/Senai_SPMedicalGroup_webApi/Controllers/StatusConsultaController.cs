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
    /// Controller responsável pelos endpoints (URLs) referentes as status
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/statusConsulta
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que qualquer usuário autenticado pode acessar aos métodos
    [Authorize]

    public class StatusConsultaController : ControllerBase
    {

        /// <summary>
        /// Objeto _stsConsultaRepository que irá receber todos os métodos definidos na interface IStatusConsultaRepository
        /// </summary>
        private IStatusConsultaRepository _statusConsultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _sttsConsultasRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public StatusConsultaController()
        {
            _statusConsultaRepository = new StatusConsultaRepository();
        }

        /// <summary>
        /// Lista todos os stsConsulta
        /// </summary>
        /// <returns>Uma lista de stsConsulta e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 200 - ok
                return Ok(_statusConsultaRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um stsConsulta pelo seu id
        /// </summary>
        /// <param name="id">id do stsConsulta</param>
        /// <returns>Um stsConsulta um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //200 - Ok
                return Ok(_statusConsultaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo stsConsulta
        /// </summary>
        /// <param name="novoStsConsulta">Objeto que sera cadastrado</param>
        /// <returns>Um status code Created</returns>
        [HttpPost]
        public IActionResult Post(StatusConsulta novoStsConsulta)
        {
            try
            {
                _statusConsultaRepository.Cadastrar(novoStsConsulta);

                // 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um stsConsulta
        /// </summary>
        /// <param name="id">id do stsConsulta</param>
        /// <param name="stsConsultaAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusConsulta stsConsultaAtualizado)
        {
            try
            {
                _statusConsultaRepository.Atualizar(id, stsConsultaAtualizado);

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
        /// Deleta um stsConsulta
        /// </summary>
        /// <param name="id">id do stsConsulta</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _statusConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

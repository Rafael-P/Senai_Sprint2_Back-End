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
    /// Controller responsável pelos endpoints (URLs) referentes as medicos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/medicos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que qualquer usuário autenticado pode acessar aos métodos
    [Authorize]

    public class MedicosController : ControllerBase
    {

        /// <summary>
        /// Objeto _medicosRepository que irá receber todos os métodos definidos na interface IMedicoRepository
        /// </summary>
        private IMedicoRepository _medicosRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _medicosRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public MedicosController()
        {
            _medicosRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista de medicos e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 200 - ok
                return Ok(_medicosRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um medico pelo seu id
        /// </summary>
        /// <param name="id">id do medico</param>
        /// <returns>Um medico e um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //200 - Ok
                return Ok(_medicosRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto que sera cadastrado</param>
        /// <returns>Um status code Created</returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicosRepository.Cadastrar(novoMedico);

                // 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um medico
        /// </summary>
        /// <param name="id">id do medico</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicosRepository.Atualizar(id, medicoAtualizado);

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
        /// Deleta um medico
        /// </summary>
        /// <param name="id">id do medico</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicosRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

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
    // ex: http://localhost:5000/api/pacientes
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que qualquer usuário autenticado pode acessar aos métodos
    [Authorize]

    public class PacienteController : ControllerBase
    {

        /// <summary>
        /// Objeto _pacientesRepository que irá receber todos os métodos definidos na interface IPacienteRepository
        /// </summary>
        private IPacienteRepository _pacientesRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _pacientesRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public PacienteController()
        {
            _pacientesRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes e um status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 200 - ok
                return Ok(_pacientesRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="id">id do paciente</param>
        /// <returns>Um paciente um status code 200 - OK</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //200 - Ok
                return Ok(_pacientesRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto que sera cadastrado</param>
        /// <returns>Um status code Created</returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacientesRepository.Cadastrar(novoPaciente);

                // 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">id do paciente</param>
        /// <param name="pacienteAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente pacienteAtualizado)
        {
            try
            {
                _pacientesRepository.Atualizar(id, pacienteAtualizado);

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
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">id do paciente</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pacientesRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

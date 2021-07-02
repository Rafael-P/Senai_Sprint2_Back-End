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
    ///  Controller responsavel pelos endpoints (URLs) referentes as instituições 
    /// </summary>

    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição sera no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/controller/Clinicas
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]

    //Define que somente o administrador pode acessar os metodos
    [Authorize(Roles = "1")]

    public class ClinicasController : ControllerBase
    {

        /// <summary>
        /// Objeto _clinicaRepository que ira receber todos os metodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o metodo
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um clinica atraves do id
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <returns>uma clinica buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que sera cadastrada</param>
        /// <returns>Um statusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id">Id da clinica</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                //Faz a chamada para o metodo
                _clinicaRepository.Atualizar(id, clinicaAtualizada);

                //retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //faz a chamada para o metodo
                _clinicaRepository.Deletar(id);

                //return um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

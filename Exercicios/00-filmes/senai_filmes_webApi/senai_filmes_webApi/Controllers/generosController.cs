using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// controller responsavel pelos edpoints(URLs) referentes aos generos
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    //define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //define que a rota de uma requisiçao sera no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/Generos
    [Route("api/[controller]")]

    //define que é um controlador de api
    [ApiController]
    public class generosController : ControllerBase
    {
        /// <summary>
        /// objeto chamado _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// instacia o objeto _generoRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public generosController()
        {
            _generoRepository = new generoRepository();
        }

        /// <summary>
        /// lista todos os generos
        /// </summary>
        /// <returns>uma lista de generos e um status code</returns>
        /// dominio/api/generos = http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            //cria uma lista nomeada listaGeneros para receber os dados
            List<generoDomain> listaGeneros = _generoRepository.ListarTodos();

            //retorna o status code 200(ok) com a lista de generos no formato JSON
            return Ok(listaGeneros); 
        }

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto chamado novoGenero recebido na requisiçao</param>
        /// <returns>um status code 201 - Created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(generoDomain novoGenero)
        {
            //faz a chamada para o metodo cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //retorna um status code 201 - Created
            return StatusCode(201);
        }

    }
}

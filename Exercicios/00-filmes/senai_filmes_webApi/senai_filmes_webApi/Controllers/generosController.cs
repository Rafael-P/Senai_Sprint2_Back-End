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
        /// busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>um genero buscado ou NotFound caso nenhum genero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //cria um objeto generoBuscado que ira receber o genero buscado no banco de dados
            generoDomain generoBuscado = _generoRepository.BuscarPorId(id);

            //verifica se nenhum genero foi encontrado
            if (generoBuscado == null)
            {
                //caso nenhum genero seja encontrado, retorna um satatus code 404 - Not found com a mensagem personalizada
                return NotFound("Nenhu gênero foi encontrado!");
            }

            //caso seja encontrado retorna o genero buscado com um status code 200 - Ok
            return Ok(generoBuscado);
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

        /// <summary>
        /// atualiza um genero existente passando o seu id pel url da requisiçao
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, generoDomain generoAtualizado)
        {
            //cria um objeto generoBuscado que irá receber o genero buscado no banco de dados
            generoDomain generoBuscado = _generoRepository.BuscarPorId(id);

            //caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            //e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }    
                );
            }

            //tenta atualizar o registro
            try
            {
                //faz a chamada para o metodo .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                //retorna um status code 204 - No Content
                return NoContent();
            }
            //caso ocorra algum erro
            catch (Exception erro)
            {
                //retorna um status 400 - BadRequest e o codigo do erro
                return BadRequest(erro); 
            } 
        } 

        /// <summary>
        /// Atualiza um genero existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">objeto generoAtualizado com as novas informaçoes </param>
        /// <returns>status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(generoDomain generoAtualizado)
        {
            //cria um objeto generoBuscado que ira receber o genero buscado no banco de dados
            generoDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            //verifica se algum genero foi encontrado
            // ! -> negação (não)
            if (generoBuscado != null)
            {
                //se sim, tenta atualizar o registro
                try
                {
                    //faz a chamada para o metodo .AtualizarIdCorpo()
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    //retorna um status code 204 - No Content
                    return NoContent();
                }

                //caso ocorra algum erro
                catch (Exception erro)
                {
                    //retorna um BadRequest e o codigo do erro
                    return BadRequest(erro);
                }
            }

            //caso não seja encontrado retorna NotFound com uma mensagem personalizada e um bool
            return NotFound
            (
                new
                {
                    mensagem = "Gênero não encontrado!",
                    erro = true
                }
            );
        }

        /// <summary>
        /// deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        /// <returns>um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o metodo .Deletar()
            _generoRepository.Deletar(id);

            //retorna um status code 204 - No Content
            return StatusCode(204);
        } 

    }
}

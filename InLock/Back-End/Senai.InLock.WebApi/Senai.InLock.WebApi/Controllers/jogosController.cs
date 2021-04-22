using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class jogosController : ControllerBase 
    {
        private IJogosRepositories _jogosRepository { get; set; }

        public jogosController()
        {
            _jogosRepository = new jogosRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<jogosDomain> listaJogos = _jogosRepository.ListarTodos();

            return Ok(listaJogos);
        }

        /// <summary>
        /// Busca pelo id
        /// </summary>
        /// <param name="id">id do jogo</param>
        /// <returns>Objeto jogoBusacdo ou notfound se nao encontrar</returns>
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            jogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo foi encontrado!");
            }
            return Ok(jogoBuscado);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto recebido na requisição</param>
        /// <returns>Um status code</returns>
        [HttpPost]
        public IActionResult Post(jogosDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um jogo 
        /// </summary>
        /// <param name="id">id do jogo que vai ser deletado</param>
        /// <returns>Um status code 204(NoContent)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um jogo
        /// </summary>
        /// <param name="id">id do jogo</param>
        /// <param name="jogoAtualizado">Objeto que recebera as novas informações</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, jogosDomain jogoAtualizado)
        {
            jogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound
                (new
                    {
                        mensagem = "O Jogo não foi encontrado :(",
                        erro = "true"
                    }
                );
            }

            try
            {
                _jogosRepository.AtualizarIdUrl(id, jogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints (URLs) referentes aos funcionarios
/// </summary>
namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // http://localhost:5000/api/Funcionarios ou FuncionariosController da no mesmo
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto chamado _funcionarioRepository que ira receber todos os metodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _funcionarioRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new funcionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios e um status code</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista chamada listaFuncionarios para receber os dados
            List<funcionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            //retorna o status code 200(ok) com a lista de generos no formato JSON
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// Busca um funcionario pelo seu id 
        /// </summary>
        /// <param name="id">id do funcionario buscado</param>
        /// <returns>Retorna um funcionario buscado ou NotFound caso não encontre nenhum funcionario</returns>
        /// http://localhost:5000/api/1
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            //Cria um objeto funcionarioBuscado que ira receber o funcionario buscado no banco de dados
            funcionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //Verifica se nenhum funcionario foi encontrado
            if (funcionarioBuscado == null)
            {
                //Caso não seja encontrado retorna um status code 404 - Not found com a mensagem personalizada
                return NotFound("Nenhum funcionario foi encontrado!");
            }

            //Caso seja encontrado retorna o funcionarioBuscado com um status code 200 - Ok
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Insere um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Objeto chamado novoFuncionario recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpPost]
        public IActionResult Post(funcionarioDomain novoFuncionario)
        {
            //Faz a chamada do metodo Inserir
            _funcionarioRepository.Inserir(novoFuncionario);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um funcionario existente
        /// </summary>
        /// <param name="id">id do funcionario</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada do metodo Deletar
            _funcionarioRepository.Deletar(id);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza um funcionario existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do funcionario</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, funcionarioDomain funcionarioAtualizado)
        {
            //cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            funcionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            //e um bool para apresentar que houve um erro
            if (funcionarioBuscado == null)
            {
                return NotFound
                (new
                    {
                        mensagem = "Funcionario não encontrado!",
                        erro = true
                    }
                );
            }

            //tenta atualizar o registro
            try
            {
                //faz a chamada para o metodo AtualizarIdUrl
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

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

    }
}

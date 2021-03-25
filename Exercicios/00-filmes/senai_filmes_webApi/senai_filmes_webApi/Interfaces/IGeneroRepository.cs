using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // estrutura de um metodo
        // TipoRetorno NomeMetodo(TipoParametro Nomeparâmetro);

        /// <summary>
        /// Busca e exibe todos os generos
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<generoDomain> ListarTodos();

        /// <summary>
        /// Busca um genero pelo seu id e exibe
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Um objeto do tipo generoDomain que foi buscado</returns>
        generoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero que sera cadastrado</param>
        void Cadastrar(generoDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo
        /// </summary>
        /// <param name="genero">objeto genero com as novas informações</param>
        void AtualizarIdCorpo(generoDomain genero);

        //  Prefiro desse jeito 
        /// <summary>
        /// Atualiza um genero existente passando o id pela url
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="genero">objeto genero com as novas informações</param>
        void AtualizarIdUrl(int id, generoDomain genero);

        /// <summary>
        /// Deleta o genero que foi encontrado pelo id
        /// </summary>
        /// <param name="id">id do genero que sera excluido</param>
        void Deletar(int id);
    }
}

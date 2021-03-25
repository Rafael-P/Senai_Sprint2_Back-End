using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    interface IFilmeRepository
    {
        //CRUD - CREATE READ UPDATE DELETE

        // estrutura de um metodo
        // TipoRetorno NomeMetodo(TipoParametro Nomeparâmetro);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">objeto que sera cadastrado</param>
        void Cadastrar(filmeDomain novoFilme);

        /// <summary>
        /// Busca e exibe todos os filmes 
        /// </summary>
        /// <returns>uma lista de filmes</returns>
        List<filmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme pelo seu id e exibe
        /// </summary>
        /// <param name="id">id do filme buscado</param>
        /// <returns>um objeto filmeDomain que foi buscado</returns>
        filmeDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um filme passando o id pela url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmeAtualizado"></param>
        void AtualizarPelaUrl(int id, filmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme pelo seu id
        /// </summary>
        /// <param name="id">id do filme que sera atualizado</param>
        void Delete(int id);
    }
}

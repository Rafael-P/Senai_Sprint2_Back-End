using Senai.InLock.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio jogosRepository
    /// </summary>
    interface IJogosRepositories 
    {
        List<jogosDomain> ListarTodos();

        jogosDomain BuscarPorId(int id);

        void Deletar(int id);

        void AtualizarIdUrl(int id, jogosDomain jogos);

        void Cadastrar(jogosDomain novoJogo);
    }
}

using Senai.InLock.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepositories
    {
        List<estudiosDomain> ListarTodos();

        estudiosDomain BuscarPorId(int id);

        void Deletar(int id);

        void AtualizarIdUrl(int id, estudiosDomain jogos);

        void Cadastrar(estudiosDomain novoJogo);
    }
}
